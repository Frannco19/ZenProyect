using Common.DTOs.Response;
using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.Request;

namespace Service.interfaces
{
    public interface ISaleService
    {
        SaleResponseDto CreateSale(CreateSaleDto dto);
        List<SaleResponseDto> GetAllSales();
        SaleResponseDto GetSaleById(int id);
        bool DeleteSale(int id);
    }

}
