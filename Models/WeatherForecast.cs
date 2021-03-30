using System;

namespace RazorMvc.webApi
{
    public class WeatherForecast
    {

        public DateTime Date { get; set; }

        public double TemperatureC { get; set; }

        public double TemperatureK
        {
            get
            {
                return TemperatureC + 273.15;
            }
        }

        public string Summary { get; set; }
    }
}
