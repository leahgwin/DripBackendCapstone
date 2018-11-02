using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DripBackendCapstoneNSS.Data;
using DripBackendCapstoneNSS.Models;

namespace DripBackendCapstoneNSS.Models.ViewModels
{
    public class ActivityViewModel
    {
    }
}






namespace BitchAbout.Models.ViewModels
{
    public class RantListViewModel
    {
        public Rant Rant { get; set; }
        public IEnumerable<Rant> Rants { get; set; }

        public RantListViewModel(ApplicationDbContext context, ApplicationUser User)
        {
            Rants = context.Rant.Where(u => u.ApplicationUserId == User.Id);


        }
    }

}