using Common.DTOs.Request;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateExpenseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = _expenseService.CreateExpense(dto);
            return Ok(response);
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

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateExpenseDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedExpense = _expenseService.UpdateExpense(id, dto);
            if (updatedExpense == null)
                return NotFound("Expense not found.");

            return Ok(updatedExpense);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _expenseService.DeleteExpense(id);
            if (!result) return NotFound("Expense not found.");
            return NoContent();
        }
    }

}
