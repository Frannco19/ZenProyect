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
        void AddFinancialReport(FinancialReport financialReport);
        FinancialReport GetFinancialReportById(int id);
        IEnumerable<FinancialReport> GetAllFinancialReports();
        void UpdateFinancialReport(FinancialReport financialReport);
        void DeleteFinancialReport(int id);
    }

}
