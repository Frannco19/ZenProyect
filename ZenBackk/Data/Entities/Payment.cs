using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Payment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Relación a la venta
        [Required]
        public int SaleId { get; set; }
        public Sale Sale { get; set; }

        // Enum de tipo de pago (Efectivo, Débito, etc.)
        [Required]
        public PaymentMethod PaymentMethod { get; set; }

        // Monto pagado
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
    }
}
