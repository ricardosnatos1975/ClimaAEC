using System.Threading.Tasks;
using ClimaAEC.Models;

namespace ClimaAEC.Services
{
    public interface IClimaAECService
    {
        Task<int> ObterECadastrarClimaCidade(int cidade);
        Task<int> ObterECadastrarClimaAeroporto(string aeroporto);
    }
}
