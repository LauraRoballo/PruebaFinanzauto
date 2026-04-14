using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // api/vehiculo
    public class VehiculoController : ControllerBase 
    {
        private readonly VehiculoService _service; 

        public VehiculoController(VehiculoService service) 
        {
            _service = service;
        }

        // Endpoint para obtener todos los vehículos
        [HttpGet]
        public async Task<IActionResult> ObtenerVehiculos()
        {
            var lista = await _service.ObtenerVehiculos();
            return Ok(lista);
        }

        // Endpoint para crear un nuevo vehículo
        [HttpPost]
        public async Task<IActionResult> CrearVehiculo([FromBody] CrearVehiculoDto dto)
        {
            try
            {
                var nuevoVehiculo = await _service.CrearVehiculo(dto); 
                return Ok(nuevoVehiculo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Endpoint para actualizar un vehículo existente busncandolo por su VIN
        [HttpPut("{vin}")] // api/vehiculo/{vin del vehículo}
        public async Task<IActionResult> ActualizarVehiculo(string vin, [FromBody] ActualizarVehiculoDto dto)
        {
            try
            {
                var actualizado = await _service.ActualizarVehiculo(vin, dto);
                return Ok(actualizado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
    




