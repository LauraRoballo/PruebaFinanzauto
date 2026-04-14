namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class CrearVehiculoDto
    {
        public string VIN { get; set; } = string.Empty; // VIN es obligatorio
        public string Modelo { get; set; } = string.Empty; // Modelo es obligatorio
        public string Color { get; set; } = string.Empty; // Color es obligatorio
        public string NombreMarca { get; set; } = string.Empty; // Aquí va el nombre
        public string? Placa { get; set; } // Opcional en el registro del vehiculo
        public decimal PrecioReferencia { get; set; } // PrecioReferencia es obligatorio
    }
}