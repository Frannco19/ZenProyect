using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class SaleDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; } // Primary Key

        [Required]
        public int SaleId { get; set; } // Sale Foreign Key
        // Navigation Properties
        [ForeignKey("SaleId")]
        public Sale Sale { get; set; }

        [Required]
        public int ProductId { get; set; } // Product Foreign Key
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; } // Quantity Sold

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal { get; set; } // Subtotal for this item

    }
}
