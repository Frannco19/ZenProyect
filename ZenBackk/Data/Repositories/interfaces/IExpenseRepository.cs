using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.interfaces
{
    public interface IExpenseRepository
    {
        void Add(Expense expense);
        Expense GetById(int id);
        IEnumerable<Expense> GetAll();
        void Update(Expense expense);
        void Delete(int id);
    }
}
