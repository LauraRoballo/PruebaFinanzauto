using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Importa anotaciones de datos para definir la estructura
namespace PruebaTecnicaFinanzauto.Models
{
    [Table("Vendedores")]
    public class Vendedores
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(70)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [StringLength(70)]
        public string Apellido { get; set; } = string.Empty;
        [Required]
        [StringLength(20)]
        public string Cedula { get; set; } = string.Empty;

        public EstadoVendedor Estado { get; set; } = EstadoVendedor.Activo; // Se llama a EstadoVendedor donde estan los estados posibles 

        public string? MotivoEstado { get; set; } 

    }
}
