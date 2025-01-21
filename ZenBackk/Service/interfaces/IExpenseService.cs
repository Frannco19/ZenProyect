using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.interfaces
{
    public interface IExpenseService
    {
        void AddExpense(Expense expense);
        Expense GetExpenseById(int id);
        IEnumerable<Expense> GetAllExpenses();
        void UpdateExpense(Expense expense);
        void DeleteExpense(int id);
    }
}
