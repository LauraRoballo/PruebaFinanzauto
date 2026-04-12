using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;

namespace PruebaTecnicaFinanzauto.Service
{
    public class MarcaService
    {
        private readonly ApplicationDbContext _context;

        public MarcaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List <Marcas> ObtenerMarcas()
        {
            return _context.Marcas.ToList();
        }

        // Crear una nueva marca
        public Marcas CrearMarcas(Marcas marca)
        {
            _context.Marcas.Add(marca);
            _context.SaveChanges();
            return marca;
        }

        public void EliminarMarca(string nombre)
        {
            var marca = _context.Marcas.FirstOrDefault(ma => ma.Nombre == nombre);

            if (marca == null)

                throw new Exception("La marca no existe");

            _context.Marcas.Remove(marca);
            _context.SaveChanges();
        }
    }
}
