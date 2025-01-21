using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.interfaces
{
    public interface ISaleDetailRepository
    {
        IEnumerable<SaleDetail> GetBySaleId(int saleId);
        IEnumerable<SaleDetail> GetByProductId(int productId);
        void Add(SaleDetail saleDetail);
    }

}
