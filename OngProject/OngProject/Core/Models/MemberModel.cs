using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public class MemberModel: EntityBase
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [MaxLength(255)]
        public string LinkedinUrl { get; set; }

        [Required]
        [MaxLength(255)]
        public string Image { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

    }
}
