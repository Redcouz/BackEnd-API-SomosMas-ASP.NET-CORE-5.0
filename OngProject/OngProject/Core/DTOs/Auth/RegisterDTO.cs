using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs.Auth
{
    public class RegisterDTO
    {
        [MaxLength(255)]
        [Required(ErrorMessage = "FirstName is required")]
        public string firstName { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "LastName is required")]
        public string lastName { get; set; }

        [MaxLength(320)]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string email { get; set; }

        [MaxLength(128)]
        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        public IFormFile photo { get; set; }
    }
}
