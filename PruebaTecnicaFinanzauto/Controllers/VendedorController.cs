using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // api/vendedor
    public class VendedorController : ControllerBase
    {
        private readonly VendedorService _service;

        public VendedorController(VendedorService service)
        {
            _service = service;
        }
        // Endpoint para obtener un vendedor por su cédula
        [HttpGet("{cedula}")]
        public async Task<IActionResult> ObtenerPorCedula(string cedula)
        {
            try
            {
                var vendedor = await _service.ObtenerPorCedula(cedula);
                return Ok(vendedor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Mensaje de error dado el caso no exista el vendedor 
            }
        }
        // Endpoint para obtener todos los vendedores
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var vendedores = await _service.ObtenerTodos();
            return Ok(vendedores);
        }

        // Endpoint para crear un nuevo vendedor
        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CrearVendedorDto dto)
        {
            var resultado = await _service.CrearVendedor(dto);
            return Ok(resultado);
        }

        // Endpoint para activar un vendedor 

        [HttpPatch("{cedula}/activar")]
        public async Task<IActionResult> Activar(string cedula)
        {
            try
            {
                await _service.ActivarVendedor(cedula);
                return Ok(new { mensaje = "Vendedor activado correctamente" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
        }

        // Endpoint para bloquear un vendedor

        [HttpPatch("{cedula}/bloquear")]
        public async Task<IActionResult> Bloquear(string cedula, [FromBody] BloquearVendedorDto dto)
        {
            try
            {
                await _service.BloquearVendedor(cedula, dto.Motivo);
                return Ok(new { mensaje = "Vendedor bloqueado correctamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Mensaje de error dado el caso no exista el vendedor
            }

          
        }

        // Endpoint para desactivar un vendedor

        [HttpPatch("{cedula}/desactivar")]
        public async Task<IActionResult> Desactivar(string cedula, [FromBody] BloquearVendedorDto dto)

        {
            try
            {
                await _service.DesactivarVendedor(cedula, dto.Motivo);
                return Ok(new { mensaje = "Vendedor desactivado correctamente" });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message); // Mensaje de error dado el caso no exista el vendedor
            }
           
        }

        // Endpoint para actualizar los datos de un vendedor
        [HttpPut("{cedula}")]
        public async Task<IActionResult> Actualizar(string cedula, [FromBody] ActualizarVendedorDto datosActualizados)
        {
                try
                {
                    await _service.ActualizarVendedor(cedula, datosActualizados);
                    return Ok(new { mensaje = "Datos actualizados correctamente" });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
           
        }
    }
}    