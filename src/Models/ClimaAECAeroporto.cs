namespace ClimaAEC.Models
{
    public class ClimaAeroporto
    {
        public string? Cidade { get; set; }
        public DateTime Data { get; set; }
        public string? Condicao { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUV { get; set; }
        public string? CondicaoDesc { get; set; }
    }
}
