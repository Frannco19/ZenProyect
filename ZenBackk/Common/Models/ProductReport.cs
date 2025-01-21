using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class ProductReport
    {
        public int ProductId { get; set; } // ID del producto
        public string ProductName { get; set; } // Nombre del producto
        public int TotalSold { get; set; } // Cantidad total vendida
        public decimal TotalRevenue { get; set; } // Ganancia total generada
    }
}
