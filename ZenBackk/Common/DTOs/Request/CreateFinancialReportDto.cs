using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class CreateFinancialReportDto
    {
        public DateTime WeekStart { get; set; }
        public DateTime WeekEnd { get; set; }
        public decimal TransferAmount { get; set; }
        public decimal DebitAmount { get; set; }
        public decimal CreditAmount { get; set; }
        public decimal CashAmount { get; set; }

        // Si decides que el frontend no envíe TotalIncome (lo calculamos nosotros),
        // no lo incluyes aquí. O podrías incluirlo y validarlo.
    }
}
