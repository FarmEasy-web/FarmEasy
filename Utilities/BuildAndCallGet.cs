using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Utilities.Helper;

namespace Utilities
{
    public class BuildAndCallGet
    {
        public static HttpClient Client { get; set; }
        public BuildAndCallGet()
        {
            Client = new HttpClient();
        }
        public static async Task<List<Value>> CallWeather(string city)
        {
            try
            {
                Client = new HttpClient();
                var culture = new CultureInfo("en-Us");
                //string uri = "https://visual-crossing-weather.p.rapidapi.com/history?dayStartTime=08:00:00&contentType=json&dayEndTime=17:00:00&shortColumnNames=false&startDateTime=" + DateTime.Now.AddDays(-500).ToString("s", culture) + "&aggregateHours=24&location=" + city + "&endDateTime=" + DateTime.Now.AddDays(-2).ToString("s", culture) + "&unitGroup=us";
                string uri = "https://visual-crossing-weather.p.rapidapi.com/history?dayStartTime=8:00:00&contentType=json&dayEndTime=17:00:00&shortColumnNames=false&startDateTime=" + DateTime.Now.AddDays(-500).Date.ToString("s", culture) + "&aggregateHours=24&location=" + city + ",GJ,India&endDateTime=" + DateTime.Now.AddDays(-2).ToString("s", culture) + "&unitGroup=us";
                Client.DefaultRequestHeaders.Add("x-rapidapi-host", "visual-crossing-weather.p.rapidapi.com");
                Client.DefaultRequestHeaders.Add("x-rapidapi-key", "59975ac606msh211b6336a2087aep1daa61jsn7d1521e01a56");
                Client.BaseAddress = new Uri(uriString: uri);
                var response = await Client.GetAsync(requestUri: uri);
                var responseString = await response.Content.ReadAsStringAsync();
                responseString = responseString.Replace(city+",GJ,India", "City");
                var weatherData = JsonConvert.DeserializeObject<WeatherData>(responseString);
                return weatherData.Locations.City.Values.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static async Task<HttpResponseMessage> CallMandiPrice(string uri)
        {            
            Client.BaseAddress = new Uri(uriString: uri);
            return await Client.GetAsync(requestUri: uri);
        }
    }
}
