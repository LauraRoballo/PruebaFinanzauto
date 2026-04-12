using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Data;

namespace PruebaTecnicaFinanzauto.Service
{
    public class VentaService
    {
        private readonly ApplicationDbContext _context; 

        // El constructor permite que .NET "inyecte" la base de datos aquí
        public VentaService(ApplicationDbContext context)
        {
            _context = context;
        }
        // Método para crear una nueva venta
        public Ventas CrearVenta(string vin, string cedula, decimal precioVenta)
        {
            var vehiculo = _context.Vehiculos.FirstOrDefault(v => v.VIN == vin); // Busca el vehículo por VIN

            if (vehiculo == null)
                throw new Exception("El vehículo no existe");

            var vendedor = _context.Vendedores.FirstOrDefault(v => v.Cedula == cedula); // Busca el vendedor por cédula

            if (vendedor == null)
                throw new Exception("El vendedor no existe");

            if (vendedor.Estado != EstadoVendedor.Activo) // Verifica que el vendedor esté activo
                throw new Exception("El vendedor no está activo");

            var venta = new Ventas 
            {
                Fecha = DateTime.Now,
                PrecioVenta = precioVenta,
                VehiculoId = vehiculo.Id,
                VendedorId = vendedor.ID
            };

            _context.Ventas.Add(venta);
            _context.SaveChanges();

            return venta;
        }

        // Método para eliminar una venta por cédula y vin (venta mal ingresada)
        public void EliminarVenta(string cedula, string vin)
        {
            var venta = _context.Ventas
                .Include(ve => ve.Vehiculo)
                .Include(ve => ve.Vendedor)
                .FirstOrDefault(ve => ve.Vehiculo.VIN == vin && ve.Vendedor.Cedula == cedula); // Busca la venta por vin y cédula)

            if (venta == null)
            {
                throw new Exception("La venta no existe");
            }
            _context.Ventas.Remove(venta);
            _context.SaveChanges();
        }
     
        // Se obtiene la vista de las ventas (VistaVenta) 
        public async Task<List<VistaVenta>> ObtenerReporteVentas() // Metodo para obtener reporteVentas sin parar el programa (async/await)
        {

            return await _context.VistaVentas.AsNoTracking().ToListAsync(); // AsNoTracking solo lee y no rastrea cambios 
        }

        // Se consulta con cedula de vendedor y se obtienen las ventas. Se utiliza el procedimiento almacenado (Stored Procedure)
        public async Task<List<VistaVenta>> ConsultarVentasPorCedula(string cedula)
        {

            if (string.IsNullOrWhiteSpace(cedula))
            {
                return new List<VistaVenta>(); // Retorna lista vacía si no hay ventas para la cédula
            }

            return await _context.VistaVentas
                 .FromSqlInterpolated($"EXEC sp_VehiculosPorVendedor {cedula}") // Ejecuta el procedimiento almacenado con la cédula como parámetro
                 .ToListAsync();
        }
    }
}