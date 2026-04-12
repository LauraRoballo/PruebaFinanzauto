using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Models;

namespace PruebaTecnicaFinanzauto.Data
{
    public class ApplicationDbContext : DbContext // Hereda de DbContext es la clase que representa la conexión a la BD 
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { } // Se crea el constructor para recibir las configuraciones de la BD

       

        // Se llaman las tablas creadas en la base de datos ubicadas en la carpeta Models y se crean como DbSet (clase generica) para que EF las reconozca y pueda mapearlas a la base de datos
        public DbSet<Models.Vehiculos> Vehiculos { get; set; }
        public DbSet<Models.Marcas> Marcas { get; set; }
        public DbSet<Models.Vendedores> Vendedores { get; set; }
        public DbSet<Models.Ventas> Ventas { get; set; }

         // Mapeo de la vista creada en la BD
        public DbSet<VistaVenta> VistaVentas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder) // configura el modelo de datos reconoce que es una vista no una tabla 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VistaVenta>(entity =>
            {
                entity.HasNoKey(); // las vistas no tiene PK
                entity.ToView("vistaVentas"); // Nombre de SQL
            });



            // Configuración adicional para Vehiculos
            modelBuilder.Entity<Vehiculos>()
            .HasIndex(v => v.VIN) // Indice en VIN para mejorar la búsqueda por VIN
            .IsUnique();// Evita por completo que existan dos vehiculos con el mismo VIN

            modelBuilder.Entity<Vehiculos>()
            .HasIndex(v => v.Placa) // Indice en Placa 
            .IsUnique(); //  Evita por completo que existan dos vehiculos con la misma placa

         
            modelBuilder.Entity<Marcas>()
                .HasIndex(m => m.Nombre)
                .IsUnique();
        

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) // Elimiación cascada, para evitar la eliminación de datos relacionados con otra tabla 
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
