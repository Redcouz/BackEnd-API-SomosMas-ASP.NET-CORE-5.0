using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class ActivitiesCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        [Required]
        [MaxLength(255)]
        public string Content { get; set; }
    }
}
