namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class CrearVentaDto
    {
        public string VIN { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }
        public string Placa { get; set; } 
    }
}