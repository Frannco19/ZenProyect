using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        void Update(Category category);
        void Delete(int id);
    }

}
