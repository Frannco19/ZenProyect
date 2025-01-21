using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Response
{
    public class SaleResponseDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        public List<SaleDetailResponseDto> SaleDetails { get; set; }
        public List<PaymentResponseDto> Payments { get; set; }
    }
}
