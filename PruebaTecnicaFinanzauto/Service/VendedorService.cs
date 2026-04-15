using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

namespace PruebaTecnicaFinanzauto.Service
{
    public class VendedorService
    {
        private readonly ApplicationDbContext _context;
        public VendedorService(ApplicationDbContext context) => _context = context;

        public async Task<List<Vendedores>> ObtenerTodos()
        {
            try
            {
            
                return await _context.Vendedores.AsNoTracking().ToListAsync();
            }
            catch (Exception) 
            {
                throw new Exception("Error de conexión con la base de datos.");
            }
        }

        public async Task DesactivarVendedor(string cedula, string motivo)
        {
            
            var ven = await _context.Vendedores.FirstOrDefaultAsync(v => v.Cedula == cedula);
            if (ven != null)
            {
                ven.Estado = EstadoVendedor.Inactivo;
                ven.MotivoEstado = motivo;
                await _context.SaveChangesAsync();
            }
        }
    

        // Bloquear con Motivo
        public async Task BloquearVendedor(string cedula, string motivo)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(v => v.Cedula == cedula);
            if (vendedor == null) throw new Exception("El vendedor no existe");

            vendedor.Estado = EstadoVendedor.Bloqueado;
            vendedor.MotivoEstado = motivo;

            await _context.SaveChangesAsync();
        }

        // Activar vendedor 
        public async Task ActivarVendedor(string cedula)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(v => v.Cedula == cedula);
            if (vendedor == null) throw new Exception("El vendedor no existe");

            vendedor.Estado = EstadoVendedor.Activo;
            vendedor.MotivoEstado = null; // Limpia el motivo al activar

            await _context.SaveChangesAsync();
        }

        // Crear vendedor
        public async Task<Vendedores> CrearVendedor(CrearVendedorDto dto)
        {
            var existe = await _context.Vendedores.AnyAsync(v => v.Cedula == dto.Cedula);
            if (existe) throw new Exception("El vendedor ya existe");

            var vendedor = new Vendedores
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Cedula = dto.Cedula,
                Estado = EstadoVendedor.Activo
            };

            _context.Vendedores.Add(vendedor);
            await _context.SaveChangesAsync();
            return vendedor;
        }

        // Actualizar vendedor 
        public async Task ActualizarVendedor(string cedulaOriginal, ActualizarVendedorDto dto)
        {
            var vendedor = await _context.Vendedores.FirstOrDefaultAsync(v => v.Cedula == cedulaOriginal);
            if (vendedor == null) throw new Exception("Vendedor no encontrado");

            if (vendedor.Estado != EstadoVendedor.Activo)
                throw new Exception("No se puede actualizar un vendedor que no está activo");

            vendedor.Nombre = dto.Nombre;
            vendedor.Apellido = dto.Apellido;
            

            await _context.SaveChangesAsync();
        }

        public async Task<List<Ventas>> ObtenerVentasReporte()
        {
            return await _context.Ventas
                .AsNoTracking() // No necesitamos rastrear cambios para un reporte ayuda con el rendimiento
                .Include(v => v.Vendedor)
                .Include(v => v.Vehiculo)
                .ToListAsync();
        }

        public async Task<Vendedores> ObtenerPorCedula(string cedula)
        {
            return await _context.Vendedores
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Cedula == cedula)
                ?? throw new Exception("Vendedor no encontrado"); 
        }
    }
}