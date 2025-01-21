using Common.DTOs.Request;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _productService.CreateProduct(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return Ok(product);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = _productService.UpdateProduct(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var result = _productService.DeleteProduct(id);
            if (!result) return NotFound();

            return NoContent();
        }

        [HttpGet("ByCategory/{categoryId}")]
        public IActionResult GetByCategoryId(int categoryId)
        {
            var products = _productService.GetProductsByCategory(categoryId);
            return Ok(products);
        }

        [HttpGet("search")]
        public IActionResult SearchProducts([FromQuery] int categoryId, [FromQuery] string nameFilter)
        {
            var products = _productService.SearchProducts(categoryId, nameFilter);
            return Ok(products);
        }

    }




}
