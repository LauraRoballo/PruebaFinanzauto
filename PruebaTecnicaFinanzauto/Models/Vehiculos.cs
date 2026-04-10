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
        [StringLength(100)]
        public string Modelo { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Color { get; set; } = string.Empty;
        [Required]
        public string Placa { get; set; } = string.Empty;

        public int MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        public virtual Marcas Marca { get; set; } = null!;
    }
}
