using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;

namespace Data.Entities
{
    public class Sale
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public DateTime Date { get; set; } // Sale Date

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; } // Total Amount

        // Navigation Property
        public ICollection<SaleDetail> SaleDetails { get; set; }

        // Navegación: Pagos asociados a la venta
        public ICollection<Payment> Payments { get; set; }
    }
}
