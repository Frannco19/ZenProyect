using Common.DTOs.Request;
using Common.DTOs.Response;
using Data.Entities;
using Data.Repositories.interfaces;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryResponseDto CreateCategory(CreateCategoryDto dto)
        {
            var category = new Category
            {
                Name = dto.Name
            };

            _categoryRepository.Add(category);

            // Convertimos la entidad a CategoryResponseDto
            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
                Products = new List<ProductResponseDto>()  // Recién creada, sin productos
            };
        }

        public CategoryResponseDto GetCategoryById(int id, bool includeProducts = false)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) return null;

            // Map a DTO
            var result = new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name,
            };

            if (includeProducts)
            {
                result.Products = category.Products.Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    // ...
                    CategoryId = p.CategoryId,
                    CategoryName = category.Name
                }).ToList();
            }

            return result;
        }

        public List<CategoryResponseDto> GetAllCategories(bool includeProducts = false)
        {
            var categories = _categoryRepository.GetAll();

            // Mapear a DTO
            var result = categories.Select(cat => new CategoryResponseDto
            {
                Id = cat.Id,
                Name = cat.Name,
                Products = includeProducts
                    ? cat.Products.Select(p => new ProductResponseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        // ...
                        CategoryId = p.CategoryId,
                        CategoryName = cat.Name
                    }).ToList()
                    : null
            }).ToList();

            return result;
        }

        public CategoryResponseDto UpdateCategory(int id, CreateCategoryDto dto)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null) return null;

            category.Name = dto.Name;
            _categoryRepository.Update(category);

            return new CategoryResponseDto
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public bool DeleteCategory(int id)
        {
            var category = _categoryRepository.GetById(id);

            if (category == null)
                return false; // No existe

            // Si la categoría tiene productos asociados:
            if (category.Products != null && category.Products.Any())
            {
                // Bloquear eliminación
                return false;
                // O lanzar una excepción, p.ej. "throw new InvalidOperationException("No se puede eliminar...");"
            }

            _categoryRepository.Delete(id);
            return true;
        }
    }


}
