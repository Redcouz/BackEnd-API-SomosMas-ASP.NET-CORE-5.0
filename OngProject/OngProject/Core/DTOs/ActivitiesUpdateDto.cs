using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class ActivitiesUpdateDto
    {
        [MaxLength(255)]
        public string Name { get; set; }

        
        public IFormFile Image { get; set; }

        [MaxLength(255)]
        public string Content { get; set; }
    }
}
