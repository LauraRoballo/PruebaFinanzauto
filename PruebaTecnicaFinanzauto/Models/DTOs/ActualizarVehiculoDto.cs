namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class ActualizarVehiculoDto
    {
        public string Modelo { get; set; } = string.Empty;
        public string MarcaNombre { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public string? Placa { get; set; }
        public decimal PrecioReferencia { get; set; }
    }
}