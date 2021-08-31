using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class OrganizationUpdateDto
    {
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }

        [Range(0, 20)]
        public int Phone { get; set; }

        [MaxLength(255)]
        public string Adress { get; set; }

        [MaxLength(320)]
        public string Email { get; set; }

        [MaxLength(255)]
        public string FacebookUrl { get; set; }

        [MaxLength(255)]
        public string LinkedinUrl { get; set; }

        [MaxLength(255)]
        public string InstagramUrl { get; set; }

        [MaxLength(500)]
        public string WelcomeText { get; set; }

        [MaxLength(2000)]
        public string AboutUsText { get; set; }
    }
}
