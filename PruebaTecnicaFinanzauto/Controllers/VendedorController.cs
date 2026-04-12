using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        // Inyectar el VendedorService para usar sus metodos 
        private readonly VendedorService _service;

        public VendedorController(VendedorService service) // El constructor es VendedorController 
        {
            _service = service;
        }

        // Endpoint para obtener un vendedor por su cedula

        [HttpGet("{cedula}")]
        public IActionResult ObtenerPorCedula(string cedula)
        {
            var vendedor = _service.ObtenerPorCedula(cedula);
            return Ok(vendedor);
        }

        // Endpoint para obtener todos los vendedores
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var vendedores = _service.ObtenerTodos();
            return Ok(vendedores);
        }

        // Endpoint para crear un nuevo vendedor
        [HttpPost]
        public IActionResult Crear([FromBody] Vendedores vendedor)
        {
            var nuevo = _service.CrearVendedor(vendedor);
            return Ok(nuevo);
        }
        // Endpoint para actualizar SOLO el estado del vendedor 
        [HttpPatch("{cedula}/activar")]
        public IActionResult Activar(string cedula)
        {
            _service.ActivarVendedor(cedula);
            return Ok();
        }

        // Endpoint para bloquear un vendedor
        [HttpPatch("{cedula}/bloquear")]
        public IActionResult Bloquear(string cedula, [FromBody] string motivo)
        {
            _service.BloquearVendedor(cedula, motivo);
            return Ok();
        }

        // Endpoint para desactivar un vendedor
        [HttpPatch("{cedula}/desactivar")]
        public IActionResult Desactivar(string cedula, [FromBody] string motivo)
        {
            _service.DesactivarVendedor(cedula, motivo);
            return Ok();
        }

        // Endpoint para actualizar los datos de un vendedor (nombre, apellido, cedula)
        [HttpPut("{cedula}")]
        public IActionResult Actualizar(string cedula, [FromBody] ActualizarVendedorDto datosActualizados)
        {
            _service.ActualizarVendedor(cedula, datosActualizados);
            return Ok();

        }
    }
}
