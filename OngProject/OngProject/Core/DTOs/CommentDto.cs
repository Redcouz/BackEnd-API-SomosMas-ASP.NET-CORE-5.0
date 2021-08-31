using OngProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class CommentDto
    {
        [Required]
        public string Body { get; set; }
    }
}
