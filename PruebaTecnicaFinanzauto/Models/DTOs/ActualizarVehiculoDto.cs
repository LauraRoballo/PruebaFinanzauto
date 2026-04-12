namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class ActualizarVehiculoDto
    {
        public string VIN { get; set; }
        public string Modelo { get; set; }
        public int MarcaId { get; set; }
        public string Color { get; set; }
        public string? Placa { get; set; }

        public decimal PrecioReferencia { get; set; }
    }
}