using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialReportController : ControllerBase
    {
        private readonly FinancialReportService _financialReportService;

        public FinancialReportController(FinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpPost]
        public IActionResult Create(FinancialReport financialReport)
        {
            _financialReportService.AddFinancialReport(financialReport);
            return Ok("Financial report created successfully.");
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var report = _financialReportService.GetFinancialReportById(id);
            if (report == null) return NotFound("Financial report not found.");
            return Ok(report);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var reports = _financialReportService.GetAllFinancialReports();
            return Ok(reports);
        }

        [HttpPut]
        public IActionResult Update(FinancialReport financialReport)
        {
            _financialReportService.UpdateFinancialReport(financialReport);
            return Ok("Financial report updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _financialReportService.DeleteFinancialReport(id);
            return Ok("Financial report deleted successfully.");
        }
    }

}
