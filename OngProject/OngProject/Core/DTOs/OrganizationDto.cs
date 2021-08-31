using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class OrganizationDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public int Phone { get; set; }
        public string Adress { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string InstagramUrl { get; set; }

        public List<SlideInfoDto> Slides { get; set; }
    }
}
