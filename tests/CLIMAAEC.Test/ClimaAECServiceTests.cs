using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using ClimaAEC.Data;
using ClimaAEC.Models;
using ClimaAEC.Repositories;
using ClimaAEC.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ClimaAEC.Tests
{
    [TestClass]
    public class ClimaAECServiceTests
    {
        private readonly string _baseUri = "https://brasilapi.com.br/api/cptec/v1/clima/";
        private readonly int _codigoCidade = 12345;
        private readonly string _codigoICAO = "SBGR";

        private Mock<HttpClient> SetupHttpClientMock()
        {
            var httpClientMock = new Mock<HttpClient>();
            var successResponse = new HttpResponseMessage(HttpStatusCode.OK);
            httpClientMock
                .Setup(client => client.SendAsync(It.IsAny<HttpRequestMessage>(), It.IsAny<System.Threading.CancellationToken>()))
                .ReturnsAsync(successResponse);

            return httpClientMock;
        }

        private ClimaAECInfo CreateClimaAECInfo()
        {
            return new ClimaAECInfo
            {
                Data = DateTime.Now,
                Condicao = "pc",
                Min = 20,
                Max = 30,
                IndiceUV = 13,
                CondicaoDesc = "Pancadas de Chuva"
            };
        }

        [TestMethod]
        public async Task ObterECadastrarClimaCidade_DeveAdicionarClimaAoDbContext()
        {
            var httpClientMock = SetupHttpClientMock();
            var dbContextMock = new Mock<AppDbContext>();

            var cidade = "Test City";
            var climaInfo = CreateClimaAECInfo();
            var response = new ClimaResponse
            {
                Cidade = cidade,
            };

            var content = new StringContent(JsonSerializer.Serialize(response));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var httpResponse = new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = content
            };

            httpClientMock
                .Setup(client => client.GetAsync($"{_baseUri}previsao/{_codigoCidade}", It.IsAny<System.Threading.CancellationToken>()))
                .ReturnsAsync(httpResponse);

            var climaService = new ClimaAECService(new ClimaAECRepositories(dbContextMock.Object));
            var climaId = await climaService.ObterECadastrarClimaCidade(_codigoCidade);
            var aeroportoId = await climaService.ObterECadastrarClimaAeroporto(_codigoICAO);
            Assert.IsNotNull(climaId);
        }
    }
}
