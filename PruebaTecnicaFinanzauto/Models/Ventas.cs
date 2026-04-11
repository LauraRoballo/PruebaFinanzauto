    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace PruebaTecnicaFinanzauto.Models
    {
        [Table("Ventas")]
        public class Ventas
        {
            [Key]
            public int Id { get; set; }
            public DateTime Fecha { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal PrecioVenta { get; set; }
            public int VehiculoId { get; set; }
            [ForeignKey("VehiculoId")]
            public virtual Vehiculos Vehiculo { get; set; } = null!;
            public int VendedorId { get; set; }
            [ForeignKey("VendedorId")]
            public virtual Vendedores Vendedor { get; set; } = null!;
        }
    }
