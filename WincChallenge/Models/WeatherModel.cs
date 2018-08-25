using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WincChallenge.Respository;

namespace WincChallenge.Models
{
    public class WeatherModel: EntityBase
    {
        public string name { get; set; }

        public main main { get; set; }

    }

    public class main
    {
        public double temp { get; set; }
        public double pressure { get; set; }
        public double humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }
}