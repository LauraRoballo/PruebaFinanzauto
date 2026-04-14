using Microsoft.EntityFrameworkCore;
using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

namespace PruebaTecnicaFinanzauto.Service
{
    public class VehiculoService
    {
        private readonly ApplicationDbContext _context; // Inyectamos DbContext 

        public VehiculoService(ApplicationDbContext context) // Constructor 
        {
            _context = context;
        }

        // Método para crear un nuevo vehículo
        public async Task<Vehiculos> CrearVehiculo(CrearVehiculoDto dto)
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(ma => ma.Nombre.ToLower() == dto.NombreMarca.ToLower().Trim()); // Buscamos la marca por nombre (ignorando mayúsculas y espacios)

            if (marca == null)
                throw new Exception($"La marca '{dto.NombreMarca}' no existe.");

            var vehiculo = new Vehiculos
            {
                VIN = dto.VIN,
                Modelo = dto.Modelo,
                Color = dto.Color,
                PrecioReferencia = dto.PrecioReferencia,
                Placa = dto.Placa, // Opcional
                MarcaId = marca.ID // No se debe escribir ya que lo lee con el nombre de marca ingresado y se adigna el Id 
            };

            _context.Vehiculos.Add(vehiculo); // Agregamos el nuevo vehiculo 
            await _context.SaveChangesAsync();

            return vehiculo;
        }

        // Obtener vehiculos con su marca relacionada en vez de Id
        public async Task<List<Vehiculos>> ObtenerVehiculos()
        {
            // Usamos .Include(v => v.Marca) para traer los datos de la tabla relacionada
            return await _context.Vehiculos
                .Include(v => v.Marca) 
                .AsNoTracking() // Mejora el rendimiento al no rastrear los cambios de las entidades (ayuda para grandes cantidades de datos que solo se deseen mostrar)
                .ToListAsync(); 
        }

        // Método para actualizar un vehículo existente
        public async Task<Vehiculos> ActualizarVehiculo(string vinOriginal, ActualizarVehiculoDto dto)
        {
            var vehiculo = await _context.Vehiculos.FirstOrDefaultAsync(v => v.VIN == vinOriginal);

            if (vehiculo == null)
                throw new Exception("El vehículo no existe.");

            // Candado de Venta
            var yaFueVendido = await _context.Ventas.AnyAsync(v => v.VehiculoId == vehiculo.Id);

            if (yaFueVendido)
                throw new Exception("No se pueden modificar los datos de un vehículo que ya cuenta con una venta registrada.");

          
            var marca = await _context.Marcas.FirstOrDefaultAsync(m => m.Nombre.ToLower() == dto.MarcaNombre.ToLower().Trim()); // Se busca la marca que se le desea actualizar al vehiculo para confirmar si existe 

            if (marca == null)
                throw new Exception($"La marca '{dto.MarcaNombre}' no existe.");

            // Si cumple todo
            vehiculo.Modelo = dto.Modelo;
            vehiculo.Color = dto.Color;
            vehiculo.PrecioReferencia = dto.PrecioReferencia;
            vehiculo.MarcaId = marca.ID;

            if (!string.IsNullOrEmpty(dto.Placa))
                vehiculo.Placa = dto.Placa;

            await _context.SaveChangesAsync();
            return vehiculo;
        }
    }
}