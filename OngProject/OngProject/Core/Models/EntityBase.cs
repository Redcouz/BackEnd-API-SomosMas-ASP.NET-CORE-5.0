using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
