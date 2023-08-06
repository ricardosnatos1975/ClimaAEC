using System.Threading.Tasks;
using ClimaAEC.Models;

namespace ClimaAEC.Repositories
{
    public interface IClimaAECRepositories
    {
        Task<int> AddClimaAsync(Clima climaAEC);
        Task SaveChangesAsync();
    }
}
