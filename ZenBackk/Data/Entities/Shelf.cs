using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Shelf
    {
        public int Id { get; set; }
        public string Name { get; set; } // "Estante #1"
        public ICollection<Product> Products { get; set; }
    }

}
