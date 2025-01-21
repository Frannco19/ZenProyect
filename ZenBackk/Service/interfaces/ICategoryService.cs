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
    public interface ICategoryService
    {
        CategoryResponseDto CreateCategory(CreateCategoryDto dto);
        CategoryResponseDto GetCategoryById(int id, bool includeProducts = false);
        List<CategoryResponseDto> GetAllCategories(bool includeProducts = false);
        CategoryResponseDto UpdateCategory(int id, CreateCategoryDto dto);
        bool DeleteCategory(int id);
    }

}
