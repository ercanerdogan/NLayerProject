using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.DTOs
{
    public class CategoryWithProductDto
    {
        public ICollection<ProductDto> Products { get; set; }
    }
}
