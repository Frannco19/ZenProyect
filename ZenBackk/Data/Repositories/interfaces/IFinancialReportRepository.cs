using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.interfaces
{
    public interface IFinancialReportRepository
    {
        void Add(FinancialReport financialReport);
        FinancialReport GetById(int id);
        IEnumerable<FinancialReport> GetAll();
        void Update(FinancialReport financialReport);
        void Delete(int id);
    }
}
