using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public class SlideModel : EntityBase
    {

        [Required]
        [MaxLength(255)]
        public string ImageUrl { get; set; }
        [Required]
        [MaxLength(255)]
        public string Text { get; set; }


        public int Order { get; set; }

        [MaxLength(255)]
        public string OrganizationId { get; set; }

    }
}
