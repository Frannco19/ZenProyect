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
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationDbContext _context;

        public SaleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Sale sale)
        {
            _context.Sales.Add(sale);
            _context.SaveChanges();
        }

        public Sale GetById(int id)
        {
            return _context.Sales
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .Include(s => s.Payments)
                .FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _context.Sales
                .Include(s => s.SaleDetails)
                .ThenInclude(sd => sd.Product)
                .Include(s => s.Payments)
                .ToList();
        }

        public bool Delete(int id)
        {
            var sale = _context.Sales.Find(id);
            if (sale == null) return false;

            _context.Sales.Remove(sale);
            _context.SaveChanges();
            return true;
        }
    }


}
