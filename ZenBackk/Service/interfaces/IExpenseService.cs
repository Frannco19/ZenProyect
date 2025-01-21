using Common.DTOs.Request;
using Common.DTOs.Response;
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
        ExpenseResponseDto CreateExpense(CreateExpenseDto dto);
        ExpenseResponseDto GetExpenseById(int id);
        List<ExpenseResponseDto> GetAllExpenses();
        ExpenseResponseDto UpdateExpense(int id, CreateExpenseDto dto);
        bool DeleteExpense(int id);

        // Métodos extra si deseas: 
        // - Por rango de fecha
        // - Por tipo de gasto
    }
}
