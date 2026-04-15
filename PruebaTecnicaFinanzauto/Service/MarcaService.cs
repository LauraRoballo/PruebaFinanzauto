using PruebaTecnicaFinanzauto.Data;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;

namespace PruebaTecnicaFinanzauto.Service
{
    public class MarcaService
    {
        private readonly ApplicationDbContext _context; // Inyctamos el contexto (DbContext) para acceder a la base de datos

        public MarcaService(ApplicationDbContext context) // Constructor 
        {
            _context = context;
        }

        // Obtener todas las marcas
        public List <Marcas> ObtenerMarcas()
        {
            return _context.Marcas.ToList();
        }

        // Crear una nueva marca
        public async Task<Marcas> CrearMarcas(Marcas marca)
        {
            
            if (string.IsNullOrWhiteSpace(marca.Nombre))
                throw new Exception("El nombre de la marca es obligatorio.");

            if (string.IsNullOrWhiteSpace(marca.PaisOrigen))
                throw new Exception("El país de origen es obligatorio.");
       

            var existe = _context.Marcas.Any(m => m.Nombre.ToLower() == marca.Nombre.ToLower());

            if (existe)
            {
                throw new Exception("La marca ya existe");
            }

            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }

        // Actualizar una marca existente por su nombre
        public Marcas ActualizarMarca(string nombre, ActualizarMarcaDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Nombre))
                throw new Exception("El nombre de la marca no puede estar vacío.");

            if (string.IsNullOrWhiteSpace(dto.PaisOrigen))
                throw new Exception("El país de origen es obligatorio para la marca.");

            var marca = _context.Marcas.FirstOrDefault(m => m.Nombre.ToLower() == nombre.ToLower()); //Buscar la marca por nombre, ignorando mayúsculas y minúsculas

            if (marca == null)
            {
                throw new Exception("La marca no existe");
            }

            var existe = _context.Marcas.Any(m => m.Nombre == dto.Nombre.ToLower() && m.ID != marca.ID); // Antes de actualizar una marca existente verifica que se este escribiendo otra marca igual (ignorando ID)

            if (existe)
            {
                throw new Exception("Ya existe otra marca con ese nombre");
            }
            //Si cumple todo

            marca.Nombre = dto.Nombre; 
            marca.PaisOrigen = dto.PaisOrigen;
            marca.Descripcion = dto.Descripcion; // Opcional

            _context.SaveChanges();

            return marca;
        }
        // Eliminar una marca por su nombre
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
