using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Response
{
    public class CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Opcional: lista de productos, si queremos devolverlos
        public List<ProductResponseDto> Products { get; set; }
    }
}
