using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VentaController : ControllerBase
    {

        private readonly VentaService _ventaService; 

        public VentaController(VentaService ventaService)
        {
            _ventaService = ventaService;
        }
        // Endpoint para consultar las ventas por cédula del vendedor (SP)
        [HttpGet("{cedula}")]
        public IActionResult ConsultarVentasPorCedula(string cedula)
        {
            var vendedor = _ventaService.ConsultarVentasPorCedula(cedula);
            return Ok(vendedor);
        }

        // Endpoint para obtener todas las ventas (VistaVenta)
        [HttpGet]
        public async Task<IActionResult> ObtenerReporteVentas()
        {
            var ventas = await _ventaService.ObtenerReporteVentas();
            return Ok(ventas);
        }

        // Endpoint para crear una nueva venta
        [HttpPost]
        public IActionResult CrearVenta(string vin, string cedula, decimal precioVenta)
        {
            var venta = _ventaService.CrearVenta(vin, cedula, precioVenta);
            return Ok(venta);
        }

        // Enpoint para eliminar una venta por cédula y vin (venta mal ingresada)
        [HttpDelete("{cedula}/{vin}")]
        public IActionResult EliminarVenta(string cedula, string vin)
        {
            _ventaService.EliminarVenta(cedula, vin);
            return NoContent();
        }
    }
}
