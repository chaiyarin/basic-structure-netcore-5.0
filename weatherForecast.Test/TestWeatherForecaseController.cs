using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using weatherForecast.Controllers;
using weatherForecast.Models;
using weatherForecast.Services;
using Xunit;

namespace weatherForecast.Test
{
    public class TestWeatherForecaseController
    {

        [Fact]
        public void TestGetNumber1Number2ShouldBeReturn3()
        {
            var mockILogger = new Mock<ILogger<WeatherForecastController>>();
            var mockCalculatorService = new Mock<ICalulatorService>();
            mockCalculatorService.Setup(service => service.SumNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(10);
            WeatherForecastController weatherForecast = new WeatherForecastController(mockILogger.Object, mockCalculatorService.Object);
            var result = weatherForecast.GetSum(1, 2);
            var objectResult = result as ObjectResult;
            ResponseResultCalculatorSum responseResultCalculator = objectResult.Value as ResponseResultCalculatorSum;
            Assert.Equal(10, responseResultCalculator.result);
        }
    }
}