using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Models;

namespace PruebaTecnicaFinanzauto.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Models.Vehiculos> Vehiculos { get; set; }
        public DbSet<Models.Marcas> Marcas { get; set; }
        public DbSet<Models.Vendedores> Vendedores { get; set; }
        public DbSet<Models.Ventas> Ventas { get; set; }

    }
}
