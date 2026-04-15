using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class VistaVenta
    {
        public DateTime Fecha { get; set; }
        public string? Placa { get; set; }
        
        public string Marca { get; set; } = string.Empty;
        public string Vehiculo { get; set; } = string.Empty;
        public string Vendedor { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }

  
        public string Cedula { get; set; } = string.Empty;
        public string VIN { get; set; } = string.Empty;
    }
}