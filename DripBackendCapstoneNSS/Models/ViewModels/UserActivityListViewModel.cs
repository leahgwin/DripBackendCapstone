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
        public UserActivity Activity { get; set; }
        public IEnumerable<UserActivity> UserActivities { get; set; }
        public UserActivity LiterTotal { get; set; }

        public UserActivityListViewModel(ApplicationDbContext context, User User)
        {
            UserActivities = context.UserActivity.Where(u => u.UserId == User.Id);
        }
    }
}