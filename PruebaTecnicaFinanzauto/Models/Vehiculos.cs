using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaFinanzauto.Models
{
    [Table("Vehiculos")]
    public class Vehiculos
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string VIN { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecioReferencia { get; set; }

        public string? Placa { get; set; } = string.Empty; // Hay vehiculos nuevos que no tienen placa aun 

        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marcas Marca { get; set; } = null!; // Relación con la tabla Marcas 
    }
}
