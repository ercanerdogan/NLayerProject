using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
