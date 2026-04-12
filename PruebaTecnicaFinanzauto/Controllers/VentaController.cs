using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Service;

namespace PruebaTecnicaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[contoller]")]
    public class VentaController : Controller
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
        public IActionResult ObtenerReporteVentas()
        {
            var vendedores = _ventaService.ObtenerReporteVentas();
            return Ok(vendedores);
        }

        // Endpoint para crear una nueva venta
        [HttpPost]
        public IActionResult CrearVenta(string placa, string cedula, decimal precioVenta)
        {
            var venta = _ventaService.CrearVenta(placa, cedula, precioVenta);
            return Ok(venta);
        }

        // Enpoint para eliminar una venta por cédula y placa (venta mal ingresada)
        [HttpDelete("{cedula}/{placa}")]
        public IActionResult EliminarVenta(string cedula, string placa)
        {
            _ventaService.EliminarVenta(cedula, placa);
            return NoContent();
        }
    }
}
