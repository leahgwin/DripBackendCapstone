using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dripCapstone.Models
{
    public class UserActivity
    {
        [Key]
        public int UserActivityId { get; set; }

        [Required]
        [DataType(DataType.Date), Display(Name = "Date of Water Usage")]
        public DateTime Date { get; set; }

        [Required]
        public int Count { get; set; }
    }
}
