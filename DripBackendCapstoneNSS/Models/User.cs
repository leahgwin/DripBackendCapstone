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

        //dont think I need username because that is built into identity? Maybe I need Id though?

        //[Key]
        //public string UserId { get; set; }

       // [Required]
        //[Display(Name = "Username")]
        //public string UserName { get; set; }

        //[Required]
        //[Display(Name = "Neighborhood")]
        //public string Neighborhood { get; set; }

        //Needs icollection of userActivity bc of one to many relationship
        public virtual ICollection<UserActivity> UserActivities { get; set; }

    }
}
