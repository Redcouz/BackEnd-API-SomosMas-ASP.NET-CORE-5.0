using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class ContactsCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        public int Phone { get; set; }
        [MaxLength(255)]
        public string Message { get; set; }
    }
}
