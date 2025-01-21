using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface ISaleDetailService
    {
        IEnumerable<SaleDetail> GetDetailsBySaleId(int saleId);
        IEnumerable<SaleDetail> GetDetailsByProductId(int productId);
    }

}
