namespace ClimaAEC.Models
{
    public class EntradaLog
    {
        public int Id { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? Mensagem { get; set; }
        public string? RastreamentoErro { get; set; }
    }
}
