using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaFinanzauto.Models.DTOs;
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
        // En VentaController.cs

        [HttpGet("{cedula}")]
        public async Task<IActionResult> ConsultarVentasPorCedula(string cedula)
        {
            
            var ventas = await _ventaService.ConsultarVentasPorCedula(cedula);

            return Ok(ventas);
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
        public async Task<IActionResult> CrearVenta([FromBody] CrearVentaDto dto)
        {
            try
            {
                var venta = await _ventaService.CrearVenta(dto);
                return Ok(venta);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // Enpoint para eliminar una venta por cédula y vin (venta mal ingresada)
        [HttpDelete("{cedula}/{vin}")]
        public async Task<IActionResult> EliminarVenta(string cedula, string vin)
        {
            try
            {
                await _ventaService.EliminarVenta(cedula, vin);
                return Ok(new { mensaje = "Venta eliminada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
