
using System.Net.Http;
using System.Threading.Tasks;
using weatherForecast.Models;
using Xunit;

namespace weatherForecast.IntegrationTest
{
    public class TestApiCalculator
    {
        [Fact]
        public async Task Test1()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("http://localhost:5000/WeatherForecast/sum/1/2");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            ResponseResultCalculatorSum responseResultCalculator = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseResultCalculatorSum>(responseBody);
            Assert.Equal(3, responseResultCalculator.result);
        }
    }
}
