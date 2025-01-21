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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ProductResponseDto CreateProduct(CreateProductDto dto)
        {
            // Validar Category
            if (dto.CategoryId <= 0)
                throw new Exception("CategoryId is required.");

            // Mapear DTO -> Entidad
            var product = new Product
            {
                Name = dto.Name,
                Stock = dto.Stock,
                CostPrice = dto.CostPrice,
                SalePrice = dto.SalePrice,
                Comments = dto.Comments,
                CategoryId = dto.CategoryId
            };

            // Guardar en repositorio
            _productRepository.Add(product);

            // Mapear Entidad -> ProductResponseDto
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                Comments = product.Comments,
                CategoryId = product.CategoryId,
                // CategoryName => product.Category?.Name (si lo incluiste con Include)
            };
        }

        public ProductResponseDto GetProductById(int id)
        {
            var product = _productRepository.GetById(id);
            if (product == null) return null;

            // Mapear a DTO
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                Comments = product.Comments,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name
            };
        }

        public List<ProductResponseDto> GetAllProducts()
        {
            var products = _productRepository.GetAll();
            // Ideal: _context.Products.Include(p => p.Category)

            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                CostPrice = p.CostPrice,
                SalePrice = p.SalePrice,
                Comments = p.Comments,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name
            }).ToList();
        }

        public ProductResponseDto UpdateProduct(int id, CreateProductDto dto)
        {
            // Traer el producto existente
            var product = _productRepository.GetById(id);
            if (product == null) return null;

            // Actualizar campos
            product.Name = dto.Name;
            product.Stock = dto.Stock;
            product.CostPrice = dto.CostPrice;
            product.SalePrice = dto.SalePrice;
            product.Comments = dto.Comments;
            product.CategoryId = dto.CategoryId;

            // Guardar
            _productRepository.Update(product);

            // Retornar un DTO
            return new ProductResponseDto
            {
                Id = product.Id,
                Name = product.Name,
                Stock = product.Stock,
                CostPrice = product.CostPrice,
                SalePrice = product.SalePrice,
                Comments = product.Comments,
                CategoryId = product.CategoryId,
                CategoryName = product.Category?.Name
            };
        }

        public bool DeleteProduct(int id)
        {
            var existingProduct = _productRepository.GetById(id);
            if (existingProduct == null) return false;

            _productRepository.Delete(id);
            return true;
        }

        public List<ProductResponseDto> GetProductsByCategory(int categoryId)
        {
            var products = _productRepository.GetProductsByCategory(categoryId);
            return products.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                // ...
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name
            }).ToList();
        }

        public List<ProductResponseDto> SearchProducts(int categoryId, string nameFilter)
        {
            var entities = _productRepository.SearchByCategoryAndName(categoryId, nameFilter);

            return entities.Select(p => new ProductResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Stock = p.Stock,
                SalePrice = p.SalePrice,
                CostPrice = p.CostPrice,
                Comments = p.Comments,
                CategoryId = p.CategoryId,
                CategoryName = p.Category?.Name
            }).ToList();
        }


    }


}
