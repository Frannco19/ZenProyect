using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Expense
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key

        [Required]
        [StringLength(200)]
        public string Description { get; set; } // Description of the expense

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } // Amount spent

        [Required]
        public DateTime Date { get; set; } // Date of the expense
    }
}
