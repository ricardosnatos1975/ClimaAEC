using Microsoft.EntityFrameworkCore;
using ClimaAEC.Models;

namespace ClimaAEC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Clima>? Climas { get; set; }
        public DbSet<EntradaLog>? EntradasLog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
