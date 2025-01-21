using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class FinancialReport
    {
        [Key]
        public int Id { get; set; } // Primary Key

        [Required]
        public DateTime WeekStart { get; set; } // Start of the week

        [Required]
        public DateTime WeekEnd { get; set; } // End of the week

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TransferAmount { get; set; } // Transfer Income

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal DebitAmount { get; set; } // Debit Card Income

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CreditAmount { get; set; } // Credit Card Income

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CashAmount { get; set; } // Cash Income

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalIncome { get; set; } // Total Income

        public bool IsClosed { get; set; } = false;
    }
}
