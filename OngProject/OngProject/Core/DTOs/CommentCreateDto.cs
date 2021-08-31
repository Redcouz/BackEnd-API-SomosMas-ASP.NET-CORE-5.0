using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class CommentCreateDto
    {
        [Required]
        public int User_id { get; set; }
        [Required]
        public int post_id { get; set; }
        [Required]
        public string Body { get; set; }
    }
}