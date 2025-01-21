using Common.DTOs.Request;
using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.interfaces;

namespace ZenBackk.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FinancialReportController : ControllerBase
    {
        private readonly IFinancialReportService _financialReportService;

        public FinancialReportController(IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        /// <summary>
        /// Crea un reporte ingresando manualmente los importes.
        /// </summary>
        [HttpPost("manual")]
        public IActionResult CreateManualReport([FromBody] CreateFinancialReportDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var report = _financialReportService.CreateManualFinancialReport(dto);
            return Ok(report);
        }

        /// <summary>
        /// Genera un reporte a partir de las ventas registradas en [start, end].
        /// </summary>
        [HttpPost("generate")]
        public IActionResult GenerateReport([FromQuery] DateTime start, [FromQuery] DateTime end)
        {
            var report = _financialReportService.GenerateFinancialReport(start, end);
            return Ok(report);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var fr = _financialReportService.GetFinancialReportById(id);
            if (fr == null) return NotFound("Report not found.");
            return Ok(fr);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allReports = _financialReportService.GetAllFinancialReports();
            return Ok(allReports);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreateFinancialReportDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updated = _financialReportService.UpdateFinancialReport(id, dto);
            if (updated == null) return NotFound("Report not found.");

            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _financialReportService.DeleteFinancialReport(id);
            if (!result) return NotFound("Report not found.");
            return NoContent();
        }

        /// <summary>
        /// Cierra (bloquea) un reporte para evitar futuras modificaciones.
        /// </summary>
        [HttpPost("{id}/close")]
        public IActionResult CloseReport(int id)
        {
            var success = _financialReportService.CloseFinancialReport(id);
            if (!success) return NotFound("Report not found.");
            return Ok("Reporte cerrado y bloqueado para ediciones.");
        }
    }
}
