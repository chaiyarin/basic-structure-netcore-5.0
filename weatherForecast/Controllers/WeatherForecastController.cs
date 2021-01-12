using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using weatherForecast.Models;
using weatherForecast.Services;

namespace weatherForecast.Controllers
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
        private readonly ICalulatorService _calculatorService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ICalulatorService calulatorService)
        {
            _logger = logger;
            _calculatorService = calulatorService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("sum/{number1}/{number2}")]
        public IActionResult GetSum(int number1, int number2)
        {
            int result = _calculatorService.SumNumber(number1, number2);
            ResponseResultCalculatorSum responseCalculator = new ResponseResultCalculatorSum();
            responseCalculator.result = result;
            return Ok(responseCalculator);
        }
    }
}
