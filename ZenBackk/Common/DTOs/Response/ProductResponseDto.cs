using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalePrice { get; set; }
        public string Comments { get; set; }

        // Si quieres mostrar también la info de la categoría:
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }

}
