using Microsoft.AspNetCore.Mvc;
using ClimaAEC.Services;

namespace ClimaAEC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimaAECController : ControllerBase
    {
        private readonly IClimaAECService _climaAECService;

        public ClimaAECController(IClimaAECService climaAECService)
        {
            _climaAECService = climaAECService;
        }
        
        [HttpGet("previsao/{codigoCidade}")]
        public async Task<IActionResult> GetClima(int codigoCidade)
        {
            try
            {
                int climaId = await _climaAECService.ObterECadastrarClimaCidade(codigoCidade);

                return Ok(new { ClimaId = climaId });
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ocorrido no processo de requisiçãot.");
            }
        }

    
        [HttpGet("aeroporto/{icaoCode}")]
        public async Task<IActionResult> GetClimaAeroporto(string icaoCode)
        {
            try
            {
                int climaId = await _climaAECService.ObterECadastrarClimaAeroporto(icaoCode);

                return Ok(new { ClimaId = climaId });
            }
            catch (Exception)
            {
                return StatusCode(500, "Erro ocorrido no processo de requisição.");
            }
        }
    }
}