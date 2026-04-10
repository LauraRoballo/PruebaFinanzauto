using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaFinanzauto.Models
{
    [Table("Marcas")] // Crea tabla "Marcas" en la base de datos
    public class Marcas
    {
        [Key]
        public int ID { get; set; }
        [Required] // El campo "Nombre" es obligatorio
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty; 
        [Required]
        public string PaisOrigen { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty; // Es opcional pero con string.Empty para evitar nulls
    }
}
