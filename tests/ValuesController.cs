using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace tests
{
    public class ValuesController
    {
        [Fact]
        public async Task Get_ReturnsAllValues()
        {
            var url = Environment.GetEnvironmentVariable("API_URL");

            if (string.IsNullOrEmpty(url))
            {
                url = "http://localhost:5000/";
            }

            var client = new HttpClient();
            var result = await client.GetAsync($"{url}api/values/");
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();
            var array = JsonConvert.DeserializeObject<string[]>(content);

            Assert.Equal(2, array.Length);
            Assert.Equal("value1", array[0]);
            Assert.Equal("value2", array[1]);
        }
    }
}
