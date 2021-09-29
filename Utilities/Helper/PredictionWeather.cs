using AutoMapper;
using Microsoft.ML;
using Microsoft.ML.Transforms.TimeSeries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helper
{
    public static class PredictionWeather
    {
        public static async Task<ModelOutput> Predict(string city)
        {
            var wD = await BuildAndCallGet.CallWeather(city);
            var year = wD.Select(y => y.DatetimeStr.Year).Distinct().ToList();
            int yc = 0;
            foreach (var i in year)
            {
                wD.Where(x => x.DatetimeStr.Year == i).ToList().ForEach(y => y.YearCount = yc);
                yc++;
            }
            var data=wD.Where(x => x.Temp == null).ToList();
            foreach(var d in data)
            {
                wD.Remove(d);
            }
            var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<Value, WeatherDataDto>()
                );
            var mapper = new Mapper(config);
            var wDDto = mapper.Map<List<WeatherDataDto>>(wD);
            var tempratureModel =await ProcessPredictAsync("Temprature", wDDto);
            //var humudityModel = ProcessPredict("HumidityCol", wD);
            return tempratureModel;
        }
        public static async Task<ModelOutput> ProcessPredictAsync(string columnName, List<WeatherDataDto> wD)
        {
            string rootDir = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../"));
            string modelPath = Path.Combine(rootDir, "MLModel.zip");
            MLContext mlContext = new MLContext();
            Microsoft.ML.IDataView dataView = mlContext.Data.LoadFromEnumerable<WeatherDataDto>(wD);
            Microsoft.ML.IDataView firstYearData = mlContext.Data.FilterRowsByColumn(dataView, "YearCount", upperBound: 1);
            Microsoft.ML.IDataView secondYearData = mlContext.Data.FilterRowsByColumn(dataView, "YearCount", lowerBound: 1);

            var forecastingPipeline = mlContext.Forecasting.ForecastBySsa(
                outputColumnName: "ForecastedValue",
                inputColumnName: columnName,
                windowSize: 7,
                seriesLength: 30,
                trainSize: 365,
                horizon: 1,
                confidenceLevel: 0.95f,
                confidenceLowerBoundColumn: "LowerValue",
                confidenceUpperBoundColumn: "UpperValue");

            SsaForecastingTransformer forecaster = forecastingPipeline.Fit(firstYearData);

            await Evaluate(secondYearData, forecaster, mlContext);

            var forecastEngine = forecaster.CreateTimeSeriesEngine<WeatherDataDto, ModelOutput>(mlContext);
            forecastEngine.CheckPoint(mlContext, modelPath);

            return await Forecast(secondYearData, 50, forecastEngine, mlContext);
        }

        private static async Task Evaluate(IDataView testData, ITransformer model, MLContext mlContext)
        {
            // Make predictions
            IDataView predictions = model.Transform(testData);

            // Actual values
            IEnumerable<double> actual =
                mlContext.Data.CreateEnumerable<WeatherDataDto>(testData, true).Select(observed => observed.Temp);

            // Predicted values
            IEnumerable<float> forecast =
                mlContext.Data.CreateEnumerable<ModelOutput>(predictions, true)
                    .Select(prediction => prediction.ForecastedValue[0]);

            // Calculate error (actual - forecast)
            var metrics = actual.Zip(forecast, (actualValue, forecastValue) => actualValue - forecastValue);

            // Get metric averages
            var MAE = metrics.Average(error => Math.Abs(error)); // Mean Absolute Error
            var RMSE = Math.Sqrt(metrics.Average(error => Math.Pow(error, 2))); // Root Mean Squared Error   
        }
        private static async Task<ModelOutput> Forecast(IDataView testData, int horizon, TimeSeriesPredictionEngine<WeatherDataDto, ModelOutput> forecaster, MLContext mlContext)
        {

            ModelOutput forecast = forecaster.Predict();

            IEnumerable<string> forecastOutput =
                mlContext.Data.CreateEnumerable<WeatherDataDto>(testData, reuseRowObject: false)
                    .Select((WeatherDataDto rental, int index) =>
                    {
                        string rentalDate = rental.DatetimeStr.ToString();
                        double actualRentals = rental.Temp;
                        float lowerEstimate = Math.Max(0, forecast.LowerValue[index]);
                        float estimate = forecast.ForecastedValue[index];
                        float upperEstimate = forecast.UpperValue[index];
                        return $"Date: {rentalDate}\n" +
                        $"Actual Rentals: {actualRentals}\n" +
                        $"Lower Estimate: {lowerEstimate}\n" +
                        $"Forecast: {estimate}\n" +
                        $"Upper Estimate: {upperEstimate}\n";
                    });
            return forecast;
        }
    }
}
