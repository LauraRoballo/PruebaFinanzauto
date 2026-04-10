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

        public async Task<List<VistaVenta>> ObtenerReporteVentas()
        {
        
            return await _context.VistaVentas.ToListAsync();
        }


        public async Task<List<VistaVenta>> ConsultarVentasPorCedula (string cedula)
        {

            if (string.IsNullOrWhiteSpace(cedula))
            {
                return new List<VistaVenta>(); // Retorna lista vacía si no hay cédula
            }

            return await _context.VistaVentas
                 .FromSqlInterpolated($"EXEC sp_VehiculosPorVendedor {cedula}")
                 .ToListAsync();
        }
    }
}