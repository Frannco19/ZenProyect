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
    public interface IFinancialReportService
    {
        /// <summary>
        /// Crea un reporte ingresando manualmente los importes de cada método de pago.
        /// Valida que (WeekEnd >= WeekStart) y recalcula el TotalIncome.
        /// </summary>
        FinancialReportResponseDto CreateManualFinancialReport(CreateFinancialReportDto dto);

        /// <summary>
        /// Genera el reporte automáticamente sumando los Payments
        /// (por PaymentMethod) dentro del rango [start, end].
        /// </summary>
        FinancialReportResponseDto GenerateFinancialReport(DateTime start, DateTime end);

        FinancialReportResponseDto GetFinancialReportById(int id);

        /// <summary>
        /// Lista todos los reportes. O si quieres filtrar por rango,
        /// podrías tener un GetByDateRange(start, end).
        /// </summary>
        List<FinancialReportResponseDto> GetAllFinancialReports();

        /// <summary>
        /// Actualiza un reporte ya existente (si no está cerrado).
        /// </summary>
        FinancialReportResponseDto UpdateFinancialReport(int id, CreateFinancialReportDto dto);

        /// <summary>
        /// Elimina un reporte (si tu negocio lo permite).
        /// </summary>
        bool DeleteFinancialReport(int id);

        /// <summary>
        /// Opcional: Cierra un reporte, impidiendo ediciones.
        /// </summary>
        bool CloseFinancialReport(int id);
    }

}
