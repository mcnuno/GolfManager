using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace GolfManagerTest
{
    [TestClass]
    public class GolfManagerTest    {
        [TestMethod]
        public async Task TestMethod1()
        {
            // start the web api host application (server)
            var webAppFactory = new WebApplicationFactory<Program>();

            var HttpClient = webAppFactory.CreateDefaultClient();

            var response = await HttpClient.GetAsync("");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.IsNotNull(stringResult);
        }
    }
}