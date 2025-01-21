using Data.Entities;
using Data.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly ApplicationDbContext _context;

        public ExpenseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Expense expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();
        }

        public Expense GetById(int id)
        {
            return _context.Expenses.FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<Expense> GetAll()
        {
            return _context.Expenses.ToList();
        }

        public void Update(Expense expense)
        {
            _context.Expenses.Update(expense);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var expense = GetById(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                _context.SaveChanges();
            }
        }
    }

}
