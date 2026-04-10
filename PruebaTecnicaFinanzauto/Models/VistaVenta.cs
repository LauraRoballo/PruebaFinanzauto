namespace PruebaTecnicaFinanzauto.Models
{
    public class VistaVenta
    {
        public DateTime Fecha { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Vehiculo { get; set; } = string.Empty;
        public string Vendedor { get; set; } = string.Empty;
        public decimal PrecioVenta { get; set; }

   
    }
}
