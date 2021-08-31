using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OngProject.Core.Models
{
    public class UserModel : EntityBase
    {

        [MaxLength(255)]
        [Required]
        public string firstName { get; set; }

        [MaxLength(255)]
        [Required]
        public string lastName { get; set; }

        [MaxLength(320)]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [MaxLength(128)]
        [Required]
        public string password { get; set; }

        [MaxLength(255)]
        public string photo { get; set; }
        
        public int roleId { get; set; } // Clave foranea hacia ID de Role
        [ForeignKey("roleId")]
        public virtual RoleModel RoleModel { get; set;}

        public static string ComputeSha256Hash(string rawData)
        {
              
            using (SHA256 sha256Hash = SHA256.Create())
            {
               
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
