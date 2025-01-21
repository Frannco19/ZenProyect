using Common.DTOs.Request;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public IActionResult CreateCategory([FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = _categoryService.CreateCategory(dto);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id, [FromQuery] bool includeProducts = false)
        {
            var category = _categoryService.GetCategoryById(id, includeProducts);
            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery] bool includeProducts = false)
        {
            var categories = _categoryService.GetAllCategories(includeProducts);
            return Ok(categories);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCategory(int id, [FromBody] CreateCategoryDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = _categoryService.UpdateCategory(id, dto);
            if (updated == null) return NotFound();

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            // Llamamos al método de servicio que elimina la categoría
            // solo si no tiene productos asociados.
            bool result = _categoryService.DeleteCategory(id);

            if (!result)
            {
                // Devuelves un mensaje de error, que puede significar 
                // "no existe" o "tiene productos asociados".
                return BadRequest("No se pudo eliminar la categoría. Tal vez tenga productos asociados.");
            }

            // Si todo va bien, regresas 204 No Content
            return NoContent();
        }

    }


}
