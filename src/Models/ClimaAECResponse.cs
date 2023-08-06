namespace ClimaAEC.Models
{
    public class ClimaResponse
    {
        public string? Cidade { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public List<ClimaAECInfo>? Clima { get; set; }
    }
}
