using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;

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
    }
}
