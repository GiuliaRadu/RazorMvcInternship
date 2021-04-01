using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using RazorMvc.Utilities;
using RazorMvc.webApi;
using RazorMvc.webApi.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RazorMvc.Tests
{
    public class DateTests
    {
        private readonly IConfiguration configuration;
        public DateTests()
        {
            configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

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
            WeatherForecastController weatherForecastController = InstantiateWweatherForecastController();


            //Act
            var weatherForcasts = weatherForecastController.FetchWeatherForecasts();

            //Assert
            Assert.Equal(8, weatherForcasts.Count);


        }

        [Fact]
        public void ConvertWeatherJsonToWeatherForecast()
        {
            //Asume
            string content = GetStreamLines();
            WeatherForecastController weatherForecastController = InstantiateWweatherForecastController();

            //Act
            var weatherForcasts = weatherForecastController.ConvertResponseContentToListOfWeatherForecast(content);
            WeatherForecast weatherForecastForTommorrow = weatherForcasts[1];

            //Assert
            Assert.Equal(285.39, weatherForecastForTommorrow.TemperatureK);
        }

        private string GetStreamLines()
        {
            var assembly = this.GetType().Assembly;
            using var stream = assembly.GetManifestResourceStream("RazorMvc.Tests.weatherForecast.json");
            StreamReader streamReader = new StreamReader(stream);

            var streamReaderLines = "";

            while (!streamReader.EndOfStream)
            {
                streamReaderLines += streamReader.ReadLine();
            }

            return streamReaderLines;
        }

        private WeatherForecastController InstantiateWweatherForecastController()
        {
            Microsoft.Extensions.Logging.ILogger<WeatherForecastController> nullLogger = new NullLogger<WeatherForecastController>();
            var weatherForecastController = new WeatherForecastController(nullLogger, configuration);
            return weatherForecastController;
        }
    }
}
