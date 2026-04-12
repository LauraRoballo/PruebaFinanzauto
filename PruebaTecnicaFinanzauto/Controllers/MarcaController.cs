using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarcaController : Controller
    {
        private readonly MarcaService _service; // Inyectar el MarcaService para usar sus metodos

        public MarcaController(MarcaService service)
        {
            _service = service;
        }

        // Endpoint para obtener todas las marcas

        [HttpGet]
        public IActionResult ObtenerMarcas()
        {
        return Ok(_service.ObtenerMarcas());
        }

        // Endpoint para crear una nueva marca
        [HttpPost]
        public IActionResult CrearMarcas(Marcas marca)
        {
            return Ok(_service.CrearMarcas(marca));
        }
        // Endpoint para eliminar una marca por su nombre
        [HttpDelete("{nombre}")]
        public IActionResult EliminarMarca(string nombre)
        {
            _service.EliminarMarca(nombre);
            return NoContent();
        }
    }
}
