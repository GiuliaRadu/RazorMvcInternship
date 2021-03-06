using System;
using System.Collections.Generic;
using System.Globalization;
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
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly double latitude;
        private readonly double longitude;
        private readonly string apiKey;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;

            latitude = double.Parse(Environment.GetEnvironmentVariable("LATITUDE") ?? configuration["WeatherForecast:latitude"], CultureInfo.InvariantCulture);
            longitude = double.Parse(Environment.GetEnvironmentVariable("LONGITUDE") ?? configuration["WeatherForecast:longitude"], CultureInfo.InvariantCulture);
            apiKey = Environment.GetEnvironmentVariable("API_KEY") ?? configuration["WeatherForecast:apiKey"];
        }

        /// <summary>
        /// Getting Weather forecast for five days for default location.
        /// </summary>
        /// <returns>List of weatherForecast objects.</returns>
        [HttpGet]
        public List<WeatherForecast> Get()
        {
            var weatherForecasts = Get(latitude, longitude);
            return weatherForecasts.GetRange(1, 5);
        }

        /// <summary>
        /// Getting Weather forecast for today and another 7 days for a specific location.
        /// </summary>
        /// <param name="latitude"> Getting values from -90 to 90. For example for Brasov: 45.657974.</param>
        /// <param name="longitude"> Getting values from -180 to 180. For example for Brasov: 25.601198.</param>
        /// <returns>List of weatherForecast objects.</returns>
        [HttpGet("/forecasts")]
        public List<WeatherForecast> Get(double latitude, double longitude)
        {
            var endpoint = $"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}";
            var client = new RestClient(endpoint);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            return ConvertResponseContentToListOfWeatherForecast(response.Content);
        }

        [NonAction]
        public List<WeatherForecast> ConvertResponseContentToListOfWeatherForecast(string content)
        {
            JToken root = JObject.Parse(content);

            JToken testToken = root["daily"];
            if(testToken == null)
            {
                JToken codToken = root["cod"];
                JToken messageToken = root["message"];
                throw new Exception($"Weather API doesn't work. Please check the Weather API : {messageToken}({codToken})");
            }
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
