using Data.Entities;
using Data.Repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FinancialReportRepository : IFinancialReportRepository
    {
        private readonly ApplicationDbContext _context;

        public FinancialReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(FinancialReport financialReport)
        {
            _context.FinancialReports.Add(financialReport);
            _context.SaveChanges();
        }

        public FinancialReport GetById(int id)
        {
            return _context.FinancialReports.FirstOrDefault(fr => fr.Id == id);
        }

        public IEnumerable<FinancialReport> GetAll()
        {
            return _context.FinancialReports.ToList();
        }

        public void Update(FinancialReport financialReport)
        {
            _context.FinancialReports.Update(financialReport);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var report = GetById(id);
            if (report != null)
            {
                _context.FinancialReports.Remove(report);
                _context.SaveChanges();
            }
        }
    }

}
