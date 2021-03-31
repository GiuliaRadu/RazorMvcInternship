using System;

namespace RazorMvc.webApi
{
    public class WeatherForecast
    {

        public DateTime Date { get; set; }

        public int TemperatureC
        {
            get { return (int)(TemperatureK - 273.15); }
        }

        public string Summary { get; set; }

        public double TemperatureK { get; set; }
    }
}
