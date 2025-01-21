using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Auto-incremental
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } // Nombre de la categoría

        // Propiedad de navegación inversa
        public List<Product> Products { get; set; } = new List<Product>();
    }

}
