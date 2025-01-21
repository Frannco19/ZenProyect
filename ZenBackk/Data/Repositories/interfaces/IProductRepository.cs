using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.interfaces
{
    public interface IProductRepository
    {
        void Add(Product product);
        Product GetById(int id);
        IEnumerable<Product> GetAll();
        void Update(Product product);
        void Delete(int id);
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Product> SearchByCategoryAndName(int categoryId, string name);

    }

}
