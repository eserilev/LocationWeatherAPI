using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WincChallenge.Respository;

namespace WincChallenge.Models
{
    public class WeatherModel
    {
        public string name { get; set; }
        public WeatherRecord[] threeHourForecast { get; set; }
        public CurrentWeather currentWeather { get; set; }
        public DateTime searchDate { get; set; }
        public Int32 zipCode { get; set; }
    }

    public class WeatherForecast
    {
        public string name { get; set; }
        public WeatherRecord[] list { get; set; }    
    }

    public class CurrentWeather
    {
        public string name { get; set; }
        public TempInfo main { get; set; }
        public WeatherDescription[] weather { get; set; }

    }


    public class WeatherRecord
    {
        public TempInfo main { get; set; }
        public WeatherDescription[] weather { get; set; }
        public DateTime dt_txt { get; set; }
    }

    public class TempInfo
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class WeatherDescription
    {
        public string main { get; set; }
        public string description { get; set; }
    }

}