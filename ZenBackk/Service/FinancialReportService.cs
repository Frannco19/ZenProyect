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
    public class FinancialReportService : IFinancialReportService
    {
        private readonly IFinancialReportRepository _financialReportRepository;

        public FinancialReportService(IFinancialReportRepository financialReportRepository)
        {
            _financialReportRepository = financialReportRepository;
        }

        public void AddFinancialReport(FinancialReport financialReport)
        {
            _financialReportRepository.Add(financialReport);
        }

        public FinancialReport GetFinancialReportById(int id)
        {
            return _financialReportRepository.GetById(id);
        }

        public IEnumerable<FinancialReport> GetAllFinancialReports()
        {
            return _financialReportRepository.GetAll();
        }

        public void UpdateFinancialReport(FinancialReport financialReport)
        {
            _financialReportRepository.Update(financialReport);
        }

        public void DeleteFinancialReport(int id)
        {
            _financialReportRepository.Delete(id);
        }
    }

}
