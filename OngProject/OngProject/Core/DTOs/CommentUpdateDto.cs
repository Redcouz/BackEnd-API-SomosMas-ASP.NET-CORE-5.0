using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.DTOs
{
    public class CommentUpdateDto
    {
        public int User_id { get; set; }
        public int post_id { get; set; }
        public string Body { get; set; }
    }
}
