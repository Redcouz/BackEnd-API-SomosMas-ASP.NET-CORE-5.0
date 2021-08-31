using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class CategoryDto
    {
        [Required]
        [DataType(DataType.Text)]
        public string Name { get; set; }
    }
}
