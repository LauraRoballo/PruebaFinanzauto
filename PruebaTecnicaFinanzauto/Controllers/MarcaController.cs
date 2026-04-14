using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/marca 
    public class MarcaController : ControllerBase 
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
        public IActionResult CrearMarcas([FromBody] Marcas marca) 
        {
            try // Manejar excepciones para evitar errores inesperados
            {
                return Ok(_service.CrearMarcas(marca)); 
            }
            catch (Exception ex) //Captura cualquier error que pueda ocurrur durante la creación de la marca 
            {
                return BadRequest(ex.Message); // el mensaje que devuelve es el que esta en MarcaService 
            }
        }

        // Endpoint para actualizar una marca por su nombre
        [HttpPut("{nombre}")] // api/marca/{nombre de la marca}
        public IActionResult ActualizarMarca(string nombre, [FromBody] ActualizarMarcaDto dto)
        {
            try
            {
                var actualizada = _service.ActualizarMarca(nombre, dto);
                return Ok(actualizada);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint para eliminar una marca por su nombre
        [HttpDelete("{nombre}")] // api/marca/{nombre de la marca}
        public IActionResult EliminarMarca(string nombre)
        {
            _service.EliminarMarca(nombre);
            return NoContent();
        }
    }
}
