using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

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
            var existe = _context.Marcas
                .Any(m => m.Nombre.ToLower() == marca.Nombre.ToLower());

            if (existe)
            {
                throw new Exception("La marca ya existe");
            }

            _context.Marcas.Add(marca);
            _context.SaveChanges();
            return marca;
        }

        public Marcas ActualizarMarca(string nombre, ActualizarMarcaDto dto)
        {
            var marca = _context.Marcas.FirstOrDefault(m => m.Nombre.ToLower() == nombre.ToLower()); //Buscar la marca por nombre, ignorando mayúsculas y minúsculas

            if (marca == null)
            {
                throw new Exception("La marca no existe");
            }

            var existe = _context.Marcas
                .Any(m => m.Nombre == dto.Nombre && m.ID != marca.ID);

            if (existe)
            {
                throw new Exception("Ya existe otra marca con ese nombre");
            }

            marca.Nombre = dto.Nombre;
            marca.PaisOrigen = dto.PaisOrigen;
            marca.Descripcion = dto.Descripcion;

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
