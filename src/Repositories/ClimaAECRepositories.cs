using ClimaAEC.Models;
using ClimaAEC.Data;

namespace ClimaAEC.Repositories
{
    public class ClimaAECRepositories : IClimaAECRepositories
    {
        private readonly AppDbContext _dbContext;

        public ClimaAECRepositories(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddClimaAsync(Clima climaAEC)
        {
            climaAEC.DataHora = DateTime.Now;
            _dbContext.Climas?.Add(climaAEC);
            await _dbContext.SaveChangesAsync();
            return climaAEC.Id;
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
