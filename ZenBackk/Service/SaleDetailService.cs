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
    public class SaleDetailService : ISaleDetailService
    {
        private readonly ISaleDetailRepository _saleDetailRepository;

        public SaleDetailService(ISaleDetailRepository saleDetailRepository)
        {
            _saleDetailRepository = saleDetailRepository;
        }

        public IEnumerable<SaleDetail> GetDetailsBySaleId(int saleId)
        {
            return _saleDetailRepository.GetBySaleId(saleId);
        }

        public IEnumerable<SaleDetail> GetDetailsByProductId(int productId)
        {
            return _saleDetailRepository.GetByProductId(productId);
        }
    }

}
