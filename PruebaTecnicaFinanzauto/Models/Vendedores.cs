using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaFinanzauto.Models
{
    [Table("Vendedores")]
    public class Vendedores
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string cedula { get; set; } = string.Empty;

    }
}
