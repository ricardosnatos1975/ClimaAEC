using Microsoft.EntityFrameworkCore;
using ClimaAEC.Data;
using ClimaAEC.Middleware;
using ClimaAEC.Repositories;
using ClimaAEC.Services;

namespace ClimaAEC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IClimaAECRepositories, ClimaAECRepositories>();
            services.AddScoped<IClimaAECService, ClimaAECService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            UseErrorHandlingMiddleware(app);

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void UseErrorHandlingMiddleware(IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
