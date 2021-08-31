using Microsoft.AspNetCore.Http;
using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class NewsUpdateDto
    {
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(65535)]
        public string Content { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
    }
}
