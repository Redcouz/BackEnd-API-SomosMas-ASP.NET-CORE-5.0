using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class SlideUpdateDto
    {
        public IFormFile Image { get; set; }
        [MaxLength(255)]
        public string Text { get; set; }
        [MaxLength(255)]
        public string OrganizationId { get; set; }
        public int? Order { get; set; }
    }
}
