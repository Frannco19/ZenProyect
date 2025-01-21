using Common.DTOs.Request;
using Common.DTOs.Response;
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

        public ExpenseResponseDto CreateExpense(CreateExpenseDto dto)
        {
            // Validar extra: que la fecha no sea futura, etc.
            if (dto.Date > DateTime.Now)
                throw new Exception("La fecha del gasto no puede ser futura.");

            var expense = new Expense
            {
                Description = dto.Description,
                Amount = dto.Amount,
                Date = dto.Date
                // ExpenseType = dto.ExpenseType, si lo tuvieras
            };

            _expenseRepository.Add(expense);

            // Map a ResponseDto
            return new ExpenseResponseDto
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date
            };
        }

        public ExpenseResponseDto GetExpenseById(int id)
        {
            var expense = _expenseRepository.GetById(id);
            if (expense == null) return null;

            return new ExpenseResponseDto
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date
            };
        }

        public List<ExpenseResponseDto> GetAllExpenses()
        {
            var expenses = _expenseRepository.GetAll();
            return expenses.Select(e => new ExpenseResponseDto
            {
                Id = e.Id,
                Description = e.Description,
                Amount = e.Amount,
                Date = e.Date
            }).ToList();
        }

        public ExpenseResponseDto UpdateExpense(int id, CreateExpenseDto dto)
        {
            var expense = _expenseRepository.GetById(id);
            if (expense == null) return null;

            expense.Description = dto.Description;
            expense.Amount = dto.Amount;
            expense.Date = dto.Date;
            // expense.ExpenseType = dto.ExpenseType;

            _expenseRepository.Update(expense);

            return new ExpenseResponseDto
            {
                Id = expense.Id,
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date
            };
        }

        public bool DeleteExpense(int id)
        {
            var expense = _expenseRepository.GetById(id);
            if (expense == null) return false;

            _expenseRepository.Delete(id);
            return true;
        }
    }


}
