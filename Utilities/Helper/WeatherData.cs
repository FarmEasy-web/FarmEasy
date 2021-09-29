using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities.Helper
{
    public partial class WeatherData
    {

        [JsonProperty("locations")]
        public Locations Locations { get; set; }
    }
    public partial class Locations
    {
        public City City { get; set; }
    }

    public partial class City
    {
        [JsonProperty("stationContributions")]
        public object StationContributions { get; set; }

        [JsonProperty("values")]
        public Value[] Values { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("name")]
        public object Name { get; set; }

        [JsonProperty("index")]
        public long Index { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("time")]
        public long Time { get; set; }

        [JsonProperty("currentConditions")]
        public object CurrentConditions { get; set; }

        [JsonProperty("alerts")]
        public object Alerts { get; set; }
    }

    public partial class Value
    {
        //[DefaultValue(value:0.0)]        
        //public double Wdir { get; set; }

        [JsonProperty("temp")]
        public double? Temp { get; set; }

        [JsonProperty("maxt")]
        public double? Maxt { get; set; }

        [JsonProperty("visibility")]
        public long? Visibility { get; set; }

        //[JsonProperty("wspd")]
        //public double Wspd { get; set; }

        [JsonProperty("datetimeStr")]
        public DateTimeOffset DatetimeStr { get; set; }

        [JsonProperty("heatindex")]
        public string Heatindex { get; set; }

        //[JsonProperty("cloudcover")]
        //public double Cloudcover { get; set; }

        [JsonProperty("mint")]
        public double? Mint { get; set; }

        [JsonProperty("datetime")]
        public long? Datetime { get; set; }

        [JsonProperty("precip")]
        public long? Precip { get; set; }

        [JsonProperty("weathertype")]
        public string Weathertype { get; set; }

        [JsonProperty("snowdepth")]
        public string Snowdepth { get; set; }

        [JsonProperty("sealevelpressure")]
        public double? Sealevelpressure { get; set; }

        [JsonProperty("dew")]
        public double? Dew { get; set; }

        [JsonProperty("humidity")]
        public double? Humidity { get; set; }

        [JsonProperty("precipcover")]
        public long? Precipcover { get; set; }

        [JsonProperty("conditions")]
        public string Conditions { get; set; }

        [JsonProperty("windchill")]
        public string Windchill { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        public double? Year { get; set; }
        public Single? Temprature
        {
            get
            {
                return Convert.ToSingle(Temp);
            }
        }
        public Single HumidityCol
        {
            get
            {
                return Convert.ToSingle(Humidity);
            }
        }
        public Single YearCount { get; set; }
    }
}
