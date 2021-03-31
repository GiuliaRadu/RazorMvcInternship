using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RazorMvc.Utilities;
using RestSharp;

namespace RazorMvc.webApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration configuration;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            this.configuration = configuration;
        }

        /// <summary>
        /// Getting Weather forecast for five days.
        /// </summary>
        /// <returns>Enumerable of weatherForecast objects.</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var weatherForecasts = (List<WeatherForecast>)FetchWeatherForecasts();
            return weatherForecasts.GetRange(1, 5);
        }

        public List<WeatherForecast> FetchWeatherForecasts()
        {
            double latitude = double.Parse(configuration["WeatherForecast:latitude"]);
            double longitude = double.Parse(configuration["WeatherForecast:longitude"]);
            var apiKey = configuration["WeatherForecast:apiKey"];

            var endpoint = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}";
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseContentToListOfWeatherForecast(response.Content);
        }

        public List<WeatherForecast> ConvertResponseContentToListOfWeatherForecast(string content)
        {
            JToken root = JObject.Parse(content);
            JToken testToken = root["daily"];
            var forecasts = new List<WeatherForecast>();

            foreach (var token in testToken)
            {
                var forecast = new WeatherForecast
                {
                    Date = DateTimeConverter.ConvertEpochToDatetime(long.Parse(token["dt"].ToString())),
                    TemperatureK = double.Parse(token["temp"]["day"].ToString()),
                    Summary = token["weather"][0]["description"].ToString(),
                };
                forecasts.Add(forecast);
            }

            return forecasts;
        }
    }
}
