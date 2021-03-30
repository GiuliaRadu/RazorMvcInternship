using RazorMvc.webApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorMvc.Utilities
{
    class WeatherApiResponse
    {
        public ApiForecast[] daily { get; set; }
    }

    class ApiForecast
    {

        public Temp temp { get; set; }

        public Weather[] weather { get; set; }

        public class Temp
        {
            public double day { get; set; }

            public double min { get; set; }

            public double max { get; set; }

            public double night { get; set; }

            public double eve { get; set; }

            public double morn { get; set; }

        }

        public class Weather
        {
            public int id { get; set; }

            public string main { get; set; }

            public string description { get; set; }

            public string icon { get; set; }

        }
    }


}
