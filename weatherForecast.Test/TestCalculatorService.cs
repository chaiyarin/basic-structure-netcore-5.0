using weatherForecast.Services;
using Xunit;

namespace weatherForecast.Test
{
    public class TestCalculatorService
    {

        [Fact]
        public void TestNumber1SumNumber2ShouldBe3()
        {
            CalulatorService calulatorService = new CalulatorService();
            int result = calulatorService.SumNumber(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void TestNumber3SumNumber3ShouldB6()
        {
            CalulatorService calulatorService = new CalulatorService();
            int result = calulatorService.SumNumber(3, 3);
            Assert.Equal(6, result);
        }
    }
}