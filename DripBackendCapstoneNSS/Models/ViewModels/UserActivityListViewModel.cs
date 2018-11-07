using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DripBackendCapstoneNSS.Data;
using DripBackendCapstoneNSS.Models;


namespace DripBackendCapstoneNSS.Models.ViewModels
{
    public class UserActivityListViewModel
    {
        public Activity Activity { get; set; }
        public UserActivity UserActivity { get; set; }
        public UserActivity Date { get; set; }
        public UserActivity UserActivityId { get; set; }
        public int Count { get; set; }
        public int Liters { get; set; }
        public IEnumerable<UserActivity> UserActivities { get; set; }

        

        public UserActivityListViewModel(ApplicationDbContext context, User User)
        {
            UserActivities = context.UserActivity.Where(u => u.UserId == User.Id);
        }

        public UserActivityListViewModel()
        {
        }
    }
}