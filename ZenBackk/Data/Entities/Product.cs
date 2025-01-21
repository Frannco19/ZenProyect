using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Nombre del producto

        [Required]
        public int Stock { get; set; } // Cantidad en stock

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal CostPrice { get; set; } // Precio de costo

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal SalePrice { get; set; } // Precio de venta

        public string Comments { get; set; } // Comentarios opcionales

        [Required]
        public int CategoryId { get; set; } // Clave foránea

        // Propiedad de navegación
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        // Ubicación en la tienda
        public int ShelfId { get; set; }
        public Shelf Shelf { get; set; } // Prop. de navegación (opcional)

    }


}

