using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

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
        public async Task<Ventas> CrearVenta(CrearVentaDto dto)
        {
            //  Buscar el vehículo y cargar su marca/ventas previas
            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.VIN == dto.VIN);

            if (vehiculo == null) throw new Exception("El vehículo no existe.");

            //  Validar marca duplicada 
            if (!string.IsNullOrEmpty(dto.Placa))
            {
                var placaExiste = await _context.Vehiculos.AnyAsync(v => v.Placa == dto.Placa && v.Id != vehiculo.Id);

                if (placaExiste) throw new Exception($"La placa {dto.Placa} ya está asignada a otro vehículo.");
            }

            // Venta duplicada 
            // Revisamos si el ID del vehículo ya aparece en la tabla de Ventas
            var yaVendido = await _context.Ventas.AnyAsync(v => v.VehiculoId == vehiculo.Id);

            if (yaVendido)
                throw new Exception("Este vehículo ya fue vendido. No se puede registrar otra venta para el mismo VIN/Placa.");

            //  Validar Vendedor (que esté activo)
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(v => v.Cedula == dto.Cedula);
            if (vendedor == null) throw new Exception("El vendedor no existe.");
            if (vendedor.Estado != EstadoVendedor.Activo) throw new Exception("Vendedor bloqueado o inactivo.");

            //  Proceder con la venta si cumple todo

            var venta = new Ventas
            {
                Fecha = DateTime.Now,
                PrecioVenta = dto.PrecioVenta,
                VehiculoId = vehiculo.Id,
                VendedorId = vendedor.ID
            };

            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return venta;
        }

        // Método para eliminar una venta por cédula del vendedor y vin (venta mal ingresada)
        public async Task EliminarVenta(string cedula, string vin)
        {
            var venta = await _context.Ventas
                .Include(ve => ve.Vehiculo)
                .Include(ve => ve.Vendedor)
                .FirstOrDefaultAsync(ve => ve.Vehiculo.VIN == vin && ve.Vendedor.Cedula == cedula);

            if (venta == null)
            {
                throw new Exception("No se encontró una venta registrada con esa cédula y ese VIN.");
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();
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
                             .ToListAsync(); // El ToListAsync es clave aquí
        }
    }
    
}