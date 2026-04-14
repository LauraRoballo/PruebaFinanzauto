namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class ActualizarVehiculoDto
    {
        public string Modelo { get; set; }
        public string MarcaNombre { get; set; } = string.Empty;
        public string Color { get; set; }
        public string? Placa { get; set; }

        public decimal PrecioReferencia { get; set; }
    }
}