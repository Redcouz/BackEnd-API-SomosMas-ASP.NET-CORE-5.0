using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OngProject.Core.Models
{
    public class TestimonialsModel : EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }

        [MaxLength(65535)]
        public string Content { get; set; }


    }
}
