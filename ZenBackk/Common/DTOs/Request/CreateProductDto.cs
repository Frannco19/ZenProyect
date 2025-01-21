using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        public decimal CostPrice { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        public string Comments { get; set; }

        // Indicamos la categoría a la que pertenece
        [Required]
        public int CategoryId { get; set; }
    }

}
