using Common.DTOs.Request;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        // 3.1 Crear una Venta
        [HttpPost]
        public IActionResult CreateSale([FromBody] CreateSaleDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var saleResponse = _saleService.CreateSale(dto);
            return Ok(saleResponse);
            // Devuelves un SaleResponseDto para que el frontend sepa el ID de la venta recién creada
        }

        // 3.2 Obtener todas las ventas (o con paginación/filtrado)
        [HttpGet]
        public IActionResult GetAll()
        {
            var sales = _saleService.GetAllSales();
            return Ok(sales);  // List<SaleResponseDto>
        }

        // 3.3 Obtener una venta por Id
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var sale = _saleService.GetSaleById(id);
            if (sale == null)
                return NotFound();

            return Ok(sale);  // SaleResponseDto
        }

        // 3.4 (Opcional) Eliminar una venta
        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var success = _saleService.DeleteSale(id);
            if (!success)
                return NotFound("Sale not found");

            return NoContent();
        }
    }


}
