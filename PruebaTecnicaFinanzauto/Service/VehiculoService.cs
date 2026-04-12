using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

namespace PruebaTecnicaFinanzauto.Service
{
    public class VehiculoService
    {

        private readonly ApplicationDbContext _context;

        public VehiculoService(ApplicationDbContext context)
        {
            _context = context;
        }


        // Método para crear un nuevo vehículo
        public Vehiculos CrearVehiculo(Vehiculos vehiculo)
        {
            var marca = _context.Marcas.FirstOrDefault(ma => ma.ID == vehiculo.MarcaId);
            if (marca == null)
                throw new Exception("La marca no existe");
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();

            return vehiculo;
        }
        // Obtener todos los vehiculos
        public List<Vehiculos> ObtenerVehiculos()
        {
            return _context.Vehiculos.ToList();
        }



        // Actualizar un vehículo existente

        public Vehiculos ActualizarVehiculo(string vin, ActualizarVehiculoDto dto)
        {
            var vehiculo = _context.Vehiculos.FirstOrDefault(v => v.VIN == vin);

            if (vehiculo == null)
                throw new Exception("El vehículo no existe");

            // validar VIN duplicado si cambia
            if (vehiculo.VIN != dto.VIN)
            {
                var existe = _context.Vehiculos.Any(v => v.VIN == dto.VIN);
                if (existe)
                    throw new Exception("Ya existe otro vehículo con ese VIN");
            }

            var marca = _context.Marcas.FirstOrDefault(m => m.ID == dto.MarcaId);
            if (marca == null)
                throw new Exception("La marca no existe");

            vehiculo.VIN = dto.VIN;
            vehiculo.Modelo = dto.Modelo;
            vehiculo.MarcaId = dto.MarcaId;
            vehiculo.Color = dto.Color;
            vehiculo.Placa = dto.Placa;
            vehiculo.PrecioReferencia = dto.PrecioReferencia;

            _context.SaveChanges();

            return vehiculo;
        }
    }
}
