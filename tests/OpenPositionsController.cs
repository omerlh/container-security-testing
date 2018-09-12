using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xunit;

namespace tests
{
    public class OpenPositionsController
    {
        [Fact]
        public async Task Get_ReturnFullstackPosition()
        {
            var url = Environment.GetEnvironmentVariable("API_URL");

            if (string.IsNullOrEmpty(url))
            {
                url = "http://localhost:5000/";
            }

            var client = new HttpClient();
            var result = await client.GetAsync($"{url}api/openpositions/");
            result.EnsureSuccessStatusCode();

            var content = await result.Content.ReadAsStringAsync();
            var openPositions = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);

            Assert.True(openPositions.ContainsKey("Fullstack Developer"));
        }
    }
}
