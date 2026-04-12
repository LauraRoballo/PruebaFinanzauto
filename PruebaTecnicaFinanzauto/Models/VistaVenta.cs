namespace PruebaTecnicaFinanzauto.Models
{
    public class VistaVenta
    {
        public DateTime Fecha { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Vehiculo { get; set; }
        public string Vendedor { get; set; }
        public decimal PrecioVenta { get; set; }
    }
}
