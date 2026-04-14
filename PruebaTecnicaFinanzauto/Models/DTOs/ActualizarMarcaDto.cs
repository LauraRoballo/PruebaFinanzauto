namespace PruebaTecnicaFinanzauto.Models.DTOs
{
    public class ActualizarMarcaDto // Estos son los datos que se permiten actualizar de una marca 
    {
        public string Nombre { get; set; } = string.Empty; // Obligatorio segun el model se Marcas
        public string PaisOrigen { get; set; } = string.Empty; // Obligatorio segun el model se Marcas
        public string Descripcion { get; set; } = string.Empty; // Opcional 
    }
}

