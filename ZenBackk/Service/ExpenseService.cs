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
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public void AddExpense(Expense expense)
        {
            _expenseRepository.Add(expense);
        }

        public Expense GetExpenseById(int id)
        {
            return _expenseRepository.GetById(id);
        }

        public IEnumerable<Expense> GetAllExpenses()
        {
            return _expenseRepository.GetAll();
        }

        public void UpdateExpense(Expense expense)
        {
            _expenseRepository.Update(expense);
        }

        public void DeleteExpense(int id)
        {
            _expenseRepository.Delete(id);
        }
    }

}
