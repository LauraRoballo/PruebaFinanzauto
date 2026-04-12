using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Models.DTOs;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class VehiculoController : ControllerBase
    {

        private readonly VehiculoService _service;

        public VehiculoController(VehiculoService service)
        {
            _service = service;
        }

        // Endpoint para obtener todos los vehiculos
        [HttpGet]
        public IActionResult ObtenerVehiculos()
        {
            return Ok(_service.ObtenerVehiculos());
        }

       
        [HttpPost]
        public IActionResult CrearVehiculo(Vehiculos vehiculo)
        {
            return Ok(_service.CrearVehiculo(vehiculo));
        }

        // Endpoint para actualizar un vehículo por su VIN

        [HttpPut("{vin}")]
        public IActionResult ActualizarVehiculo(string vin, [FromBody] ActualizarVehiculoDto dto)
        {
            var actualizado = _service.ActualizarVehiculo(vin, dto);
            return Ok(actualizado);
        }

    }
    }
    




