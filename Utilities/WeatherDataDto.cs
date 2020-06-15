using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class WeatherDataDto
    {
        
        public double Temp { get; set; }

        
        public double Maxt { get; set; }

        
        public long Visibility { get; set; }

        //[JsonProperty("wspd")]
        //public double Wspd { get; set; }

        
        public DateTimeOffset DatetimeStr { get; set; }

        
        public string Heatindex { get; set; }

        //[JsonProperty("cloudcover")]
        //public double Cloudcover { get; set; }

        
        public double Mint { get; set; }

        
        public long Datetime { get; set; }

        
        public long Precip { get; set; }

        
        public string Weathertype { get; set; }

        
        public string Snowdepth { get; set; }

        
        public double Sealevelpressure { get; set; }

        
        public double Dew { get; set; }

        
        public double Humidity { get; set; }

        
        public long Precipcover { get; set; }

        
        public string Conditions { get; set; }

        
        public string Windchill { get; set; }
        
        public string Info { get; set; }

        public double Year { get; set; }
        public Single Temprature
        {
            get;set;
        }
        public Single HumidityCol
        {
            
               get;set;            
        }
        public Single YearCount { get; set; }
    }
}
