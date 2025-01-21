using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly ExpenseService _expenseService;

        public ExpenseController(ExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public IActionResult Create(Expense expense)
        {
            _expenseService.AddExpense(expense);
            return Ok("Expense created successfully.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var expense = _expenseService.GetExpenseById(id);
            if (expense == null) return NotFound("Expense not found.");
            return Ok(expense);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = _expenseService.GetAllExpenses();
            return Ok(expenses);
        }

        [HttpPut]
        public IActionResult Update(Expense expense)
        {
            _expenseService.UpdateExpense(expense);
            return Ok("Expense updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _expenseService.DeleteExpense(id);
            return Ok("Expense deleted successfully.");
        }
    }

}
