using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DripBackendCapstoneNSS.Models
{
    public class UserActivity
    {
        [Key]
        public int UserActivityId { get; set; }

        [Required]
        [DataType(DataType.Date), Display(Name = "Date of Water Usage")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "How many times?")]
        public int Count { get; set; }

        public User User { get; set; }

        public string Id { get; set; }

        public Activity Activity { get; set; }

        public int ActivityId { get; set; }

        [NotMapped]
        public int LiterTotal { get; set; }

        //method to do the multiplication of liters and count
        public int SetLiterTotal()
        {
            LiterTotal = Count * Activity.Liters;
            return LiterTotal;
        }
    }
}
