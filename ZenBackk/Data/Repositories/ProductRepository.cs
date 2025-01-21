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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public Product GetById(int id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public void Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public IEnumerable<Product> SearchByCategoryAndName(int categoryId, string name)
        {
            return _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId &&
                            p.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

    }

}
