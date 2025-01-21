using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class CreateSaleDto
    {
        public DateTime Date { get; set; }
        public decimal Total { get; set; }

        // Detalles de productos
        public List<SaleDetailDto> SaleDetails { get; set; }

        // Métodos de pago
        public List<PaymentDto> Payments { get; set; }
    }
}
