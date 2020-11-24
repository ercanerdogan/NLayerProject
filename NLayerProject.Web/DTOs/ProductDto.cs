using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [Range(1, int.MaxValue, ErrorMessage ="{0} field value must bigger than 1.")]
        public int Stock { get; set; }
    }
}
