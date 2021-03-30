using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Getting Weather forecast for five days.
        /// </summary>
        /// <returns>Enumerable of weatherForecast objects.</returns>
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            })
            .ToArray();
        }

        public IList<WeatherForecast> FetchWeatherForecasts(double latitude, double longitude, string apiKey)
        {
            var endpoint = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}";
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseContentToListOfWeatherForecast(response.Content);
        }

        private IList<WeatherForecast> ConvertResponseContentToListOfWeatherForecast(string content)
        {
            var apiResponse = JsonSerializer.Deserialize<WeatherApiResponse>(content);

            List <WeatherForecast> forecasts = new List<WeatherForecast>();

            for (int i = 0; i < apiResponse.daily.Length; i++)
            {
                double tempK = apiResponse.daily[i].temp.day;
                string summary = apiResponse.daily[i].weather[0].description;

                forecasts.Add(new WeatherForecast
                {
                    TemperatureC = tempK - 273.15,
                    Summary = summary,
                });

            }

            return forecasts;
        }
    }
}
