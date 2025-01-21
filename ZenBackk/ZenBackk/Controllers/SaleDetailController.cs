using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleDetailController : ControllerBase
    {
        private readonly ISaleDetailService _saleDetailService;

        public SaleDetailController(ISaleDetailService saleDetailService)
        {
            _saleDetailService = saleDetailService;
        }

        [HttpGet("by-sale/{saleId}")]
        public IActionResult GetDetailsBySaleId(int saleId)
        {
            var details = _saleDetailService.GetDetailsBySaleId(saleId);
            return Ok(details);
        }

        [HttpGet("by-product/{productId}")]
        public IActionResult GetDetailsByProductId(int productId)
        {
            var details = _saleDetailService.GetDetailsByProductId(productId);
            return Ok(details);
        }
    }

}
