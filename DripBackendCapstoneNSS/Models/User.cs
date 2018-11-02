using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DripBackendCapstoneNSS.Models
{
    public class User : IdentityUser
    {
        public User()
        {

        }

        [Key]
        public int UserId { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Neighborhood")]
        public string Neighborhood { get; set; }

    }
}
