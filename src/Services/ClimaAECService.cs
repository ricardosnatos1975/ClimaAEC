using System;
using System.Net.Http;
using System.Threading.Tasks;
using ClimaAEC.Data;
using ClimaAEC.Models;
using ClimaAEC.Repositories;

namespace ClimaAEC.Services
{
    public class ClimaAECService : IClimaAECService
    {
        private readonly IClimaAECRepositories _climaAECRepositories;
        private readonly HttpClient _httpClient;

        public ClimaAECService(IClimaAECRepositories climaAECRepositories)
        {
            _climaAECRepositories = climaAECRepositories;
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://brasilapi.com.br/api/cptec/v1/clima/")
            };
        }

        public async Task<int> ObterECadastrarClimaAeroporto(string icaoCode)
        {
            var response = await _httpClient.GetFromJsonAsync<ClimaAeroporto>($"aeroporto/{icaoCode}");

            if (response != null)
            {
                var clima = new Clima
                {
                    Aeroporto = response?.Cidade ?? throw new Exception("Cidade do aeroporto não encontrada."),
                    Data = response.Data,
                    Condicao = response.Condicao,
                    Min = response.Min,
                    Max = response.Max,
                    IndiceUV = response.IndiceUV,
                    Descricao = response.CondicaoDesc,
                };

                await _climaAECRepositories.AddClimaAsync(clima);
                await _climaAECRepositories.SaveChangesAsync();

                return clima.Id;
            }
            else
            {
                throw new Exception("Falha ao obter o clima do aeroporto");
            }
        }

        public async Task<int> ObterECadastrarClimaCidade(int codigoCidade)
        {
            var response = await _httpClient.GetFromJsonAsync<ClimaResponse>($"previsao/{codigoCidade}");

            if (response != null && response.Clima != null)
            {
                var climaInfo = response.Clima[0];

                var clima = new Clima
                {
                    Cidade = response?.Cidade ?? throw new Exception("Cidade não encontrada."),
                    Data = climaInfo.Data,
                    Condicao = climaInfo.Condicao,
                    Min = climaInfo.Min,
                    Max = climaInfo.Max,
                    IndiceUV = climaInfo.IndiceUV,
                    Descricao = climaInfo.CondicaoDesc,
                };

                await _climaAECRepositories.AddClimaAsync(clima);
                await _climaAECRepositories.SaveChangesAsync();

                return clima.Id;
            }
            else
            {
                throw new Exception("Falha ao obter o clima da cidade");
            }
        }
    }
}
