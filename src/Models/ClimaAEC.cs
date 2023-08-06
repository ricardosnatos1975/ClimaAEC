namespace ClimaAEC.Models
{
    public class Clima
    {
        public int Id { get; set; }
        public string? Cidade { get; set; }
        public string? Aeroporto { get; set; }
        public DateTime Data { get; set; }
        public string? Condicao { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUV { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataHora {get; set;}
    }
}
