using Data.Entities;
using Data.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class SaleDetailRepository : ISaleDetailRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleDetailRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SaleDetail> GetBySaleId(int saleId)
        {
            return _context.SaleDetails
                .Include(sd => sd.Product)
                .Where(sd => sd.SaleId == saleId)
                .ToList();
        }

        public IEnumerable<SaleDetail> GetByProductId(int productId)
        {
            return _context.SaleDetails
                .Include(sd => sd.Sale)
                .Where(sd => sd.ProductId == productId)
                .ToList();
        }

        public void Add(SaleDetail saleDetail)
        {
            _context.SaleDetails.Add(saleDetail);
            _context.SaveChanges();
        }
    }

}
