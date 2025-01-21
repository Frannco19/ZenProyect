using Common.DTOs.Request;
using Common.DTOs.Response;
using Common.Enums;
using Data;
using Data.Entities;
using Data.Repositories.interfaces;
using Microsoft.EntityFrameworkCore;
using Service.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly IFinancialReportRepository _financialReportRepository;
        // Necesitarás acceder a Payments para la generación automática:
        private readonly ApplicationDbContext _context;

        public FinancialReportService(IFinancialReportRepository financialReportRepository,
                                      ApplicationDbContext context)
        {
            _financialReportRepository = financialReportRepository;
            _context = context; // o inyecta un IPaymentRepository si lo prefieres
        }

        public FinancialReportResponseDto CreateManualFinancialReport(CreateFinancialReportDto dto)
        {
            // Validar fechas
            if (dto.WeekEnd < dto.WeekStart)
                throw new Exception("WeekEnd cannot be before WeekStart.");

            // Calcular TotalIncome = Transfer + Debit + Credit + Cash
            decimal total = dto.TransferAmount + dto.DebitAmount + dto.CreditAmount + dto.CashAmount;

            var entity = new FinancialReport
            {
                WeekStart = dto.WeekStart,
                WeekEnd = dto.WeekEnd,
                TransferAmount = dto.TransferAmount,
                DebitAmount = dto.DebitAmount,
                CreditAmount = dto.CreditAmount,
                CashAmount = dto.CashAmount,
                TotalIncome = total,
                IsClosed = false
            };

            _financialReportRepository.Add(entity);

            return MapToResponseDto(entity);
        }

        public FinancialReportResponseDto GenerateFinancialReport(DateTime start, DateTime end)
        {
            // 1) Traer todos los Payments en el rango
            var paymentsInRange = _context.Payments
                .Include(p => p.Sale)
                .Where(p => p.Sale.Date >= start && p.Sale.Date <= end)
                .ToList();

            // 2) Agrupar sumas por método de pago
            decimal transferSum = paymentsInRange
                .Where(p => p.PaymentMethod == PaymentMethod.Transferencia)
                .Sum(p => p.Amount);

            decimal debitSum = paymentsInRange
                .Where(p => p.PaymentMethod == PaymentMethod.Debito)
                .Sum(p => p.Amount);

            decimal creditSum = paymentsInRange
                .Where(p => p.PaymentMethod == PaymentMethod.Credito)
                .Sum(p => p.Amount);

            decimal cashSum = paymentsInRange
                .Where(p => p.PaymentMethod == PaymentMethod.Efectivo)
                .Sum(p => p.Amount);

            decimal total = transferSum + debitSum + creditSum + cashSum;

            // 3) Crear y guardar el reporte
            var report = new FinancialReport
            {
                WeekStart = start,
                WeekEnd = end,
                TransferAmount = transferSum,
                DebitAmount = debitSum,
                CreditAmount = creditSum,
                CashAmount = cashSum,
                TotalIncome = total,
                IsClosed = false
            };

            _financialReportRepository.Add(report);

            return MapToResponseDto(report);
        }

        public FinancialReportResponseDto GetFinancialReportById(int id)
        {
            var report = _financialReportRepository.GetById(id);
            if (report == null) return null;

            return MapToResponseDto(report);
        }

        public List<FinancialReportResponseDto> GetAllFinancialReports()
        {
            var reports = _financialReportRepository.GetAll();
            return reports.Select(MapToResponseDto).ToList();
        }

        public FinancialReportResponseDto UpdateFinancialReport(int id, CreateFinancialReportDto dto)
        {
            var entity = _financialReportRepository.GetById(id);
            if (entity == null) return null;

            if (entity.IsClosed)
                throw new Exception("This report is closed and cannot be updated.");

            if (dto.WeekEnd < dto.WeekStart)
                throw new Exception("WeekEnd cannot be before WeekStart.");

            decimal total = dto.TransferAmount + dto.DebitAmount + dto.CreditAmount + dto.CashAmount;

            entity.WeekStart = dto.WeekStart;
            entity.WeekEnd = dto.WeekEnd;
            entity.TransferAmount = dto.TransferAmount;
            entity.DebitAmount = dto.DebitAmount;
            entity.CreditAmount = dto.CreditAmount;
            entity.CashAmount = dto.CashAmount;
            entity.TotalIncome = total;

            _financialReportRepository.Update(entity);
            return MapToResponseDto(entity);
        }

        public bool DeleteFinancialReport(int id)
        {
            var report = _financialReportRepository.GetById(id);
            if (report == null) return false;

            _financialReportRepository.Delete(id);
            return true;
        }

        public bool CloseFinancialReport(int id)
        {
            var report = _financialReportRepository.GetById(id);
            if (report == null) return false;

            report.IsClosed = true;
            _financialReportRepository.Update(report);
            return true;
        }

        // Helper para mapear la entidad => DTO
        private FinancialReportResponseDto MapToResponseDto(FinancialReport fr)
        {
            return new FinancialReportResponseDto
            {
                Id = fr.Id,
                WeekStart = fr.WeekStart,
                WeekEnd = fr.WeekEnd,
                TransferAmount = fr.TransferAmount,
                DebitAmount = fr.DebitAmount,
                CreditAmount = fr.CreditAmount,
                CashAmount = fr.CashAmount,
                TotalIncome = fr.TotalIncome,
                IsClosed = fr.IsClosed
            };
        }
    }
}
