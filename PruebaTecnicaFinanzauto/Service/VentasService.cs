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

        public Ventas CrearVenta(Ventas venta)
        {
            var existe = _context.Vehiculos.FirstOrDefault(v => v.Id == venta.VehiculoId);  // Verificar si el vehículo existe

            if (existe == null)
            {
                throw new Exception("El vehiculo no existe");
            }
            _context.Ventas.Add(venta); // Agrega la venta a la base de datos
            _context.SaveChanges(); // Guarda los cambios en la base de datos
            return venta; 
        }

        public void EliminarVenta(string cedula, string placa)
        {
            var venta = _context.Ventas
                .Include(ve => ve.Vehiculo)
                .Include(ve => ve.Vendedor)
                .FirstOrDefault(ve => ve.Vehiculo.Placa == placa && ve.Vendedor.Cedula == cedula); // Busca la venta por placa y cédula)

            if (venta == null)
            {
                throw new Exception("La venta no existe");
            }
            _context.Ventas.Remove(venta);
            _context.SaveChanges();
        }
     

        public async Task<List<VistaVenta>> ObtenerReporteVentas() // Metodo para obtener reporteVentas sin parar el programa (async/await)
        {

            return await _context.VistaVentas.AsNoTracking().ToListAsync(); // AsNoTracking solo lee y no rastrea cambios 
        }


        public async Task<List<VistaVenta>> ConsultarVentasPorCedula(string cedula)
        {

            if (string.IsNullOrWhiteSpace(cedula))
            {
                return new List<VistaVenta>(); // Retorna lista vacía si no hay cédula
            }

            return await _context.VistaVentas
                 .FromSqlInterpolated($"EXEC sp_VehiculosPorVendedor {cedula}") // Ejecuta el procedimiento almacenado con la cédula como parámetro
                 .ToListAsync();
        }
    }
}