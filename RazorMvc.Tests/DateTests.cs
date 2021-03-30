using Microsoft.Extensions.Logging.Abstractions;
using RazorMvc.Utilities;
using RazorMvc.webApi;
using RazorMvc.webApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RazorMvc.Tests
{
    public class DateTests
    {

        [Fact]
        public void checkEpochConversion()
        {
            // Assume
            long ticks = 1617184800;

            // Act

            DateTime dateTime = DateTimeConverter.ConvertEpochToDatetime(ticks);

            // Assert
            Assert.Equal(2021, dateTime.Year);
            Assert.Equal(3, dateTime.Month);
            Assert.Equal(31, dateTime.Day);
        }

        [Fact]
        public void convertOutputOfWeatherAPIToWeatherForecast()
        {
            // Assume
            // https://api.openweathermap.org/data/2.5/onecall?lat=45.75&lon=25.3333&exclude=hourly,minutely&appid=8ea3b1799c36aefca813bbb70b937d96

            var latitude = 45.75;
            var longitude = 25.3333;
            var APIKey = "8ea3b1799c36aefca813bbb70b937d96";
            Microsoft.Extensions.Logging.ILogger<WeatherForecastController> nullLogger = new NullLogger<WeatherForecastController>();
            var weatherForecastController = new WeatherForecastController(nullLogger);
            // Act
            var weatherForecasts = weatherForecastController.FetchWeatherForecasts(latitude, longitude, APIKey);
            WeatherForecast weatherForecastForTomorrow = weatherForecasts[1];


            // Assert
            Assert.Equal(284.07, weatherForecastForTomorrow.TemperatureK);


        }
       
    }
}
