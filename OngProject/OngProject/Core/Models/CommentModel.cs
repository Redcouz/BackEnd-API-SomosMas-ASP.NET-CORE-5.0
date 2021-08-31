using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public class CommentModel : EntityBase
    {
      
    public int User_id { get; set; }
       
    public int post_id { get; set; }
        
    [Required]
    public string Body { get; set; }

    }
}
