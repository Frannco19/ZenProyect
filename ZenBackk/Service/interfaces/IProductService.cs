using Common.DTOs.Request;
using Common.DTOs.Response;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface IProductService
    {
        ProductResponseDto CreateProduct(CreateProductDto dto);
        ProductResponseDto GetProductById(int id);
        List<ProductResponseDto> GetAllProducts();
        ProductResponseDto UpdateProduct(int id, CreateProductDto dto);
        bool DeleteProduct(int id);
        List<ProductResponseDto> GetProductsByCategory(int categoryId);

        List<ProductResponseDto> SearchProducts(int categoryId, string nameFilter);

    }
}
