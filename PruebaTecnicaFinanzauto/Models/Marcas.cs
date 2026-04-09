using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaTecnicaFinanzauto.Models
{
    [Table("Marcas")]
    public class Marcas
    {
        [Key]
        public int ID { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string PaisOrigen { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
