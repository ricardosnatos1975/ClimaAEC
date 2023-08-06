using System.Net;
using ClimaAEC.Data;
using ClimaAEC.Models;

namespace ClimaAEC.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly AppDbContext _dbContext;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, AppDbContext dbContext)
        {
            _next = next;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Um Erro Inexperado Ocorrido");

                var logEntry = new EntradaLog
                {
                    DataRegistro = DateTime.Now,
                    Mensagem = ex.Message,
                    RastreamentoErro = ex.StackTrace
                };

                _dbContext.EntradasLog?.Add(logEntry);
                await _dbContext.SaveChangesAsync();

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var errorMessage = "Erro Inesperado Ocorrido.";
                await context.Response.WriteAsync(errorMessage);
            }
        }
    }
}
