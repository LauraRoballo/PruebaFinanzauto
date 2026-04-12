using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class VehiculoController : Controller
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
        }
    }




