using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Response
{
    public class SaleDetailResponseDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }   // Se lo añades si quieres devolver también el nombre
        public int Quantity { get; set; }
        public decimal Subtotal { get; set; }
    }
}
