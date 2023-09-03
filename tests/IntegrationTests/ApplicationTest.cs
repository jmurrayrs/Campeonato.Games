using System.Net;
using System.Text;
using Campeonato.Application.Models;
using Campeonato.Tests.Helpers;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace Campeonato.Tests.IntegrationTests
{
    public class ApplicationTest : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _webApplicationFactory;

        public ApplicationTest(WebApplicationFactory<Program> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
        }

        [Fact]
        public async Task TestGetEndpoint()
        {
            var payload = new
            {
                games = new GameHelper().GenerateRandomicGameModelList()
            };

            var jsonContent = JsonConvert.SerializeObject(payload);

            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            //string requestBody = content.ReadAsStringAsync().Result;

            var httpClient = _webApplicationFactory.CreateClient();

            var response = await httpClient.PostAsync("/create", content);

            Assert.True(response.StatusCode == HttpStatusCode.OK);
        }
    }
}