using DripBackendCapstoneNSS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DripBackendCapstoneNSS.Models.ViewModels
{
    public class UserActivityCreateViewModel
    {
            public List<SelectListItem> Activities { get; set; }
            public SelectList ActivitiesList { get; set; }
        //have new property for userActivity (userAcvitivt.count)


        //this is the dropdown for selecting which activity you want to create
        public UserActivityCreateViewModel(ApplicationDbContext context)
            {
                Activities = context.Activity.Select(activity =>
                new SelectListItem { Text = activity.Name, Value = activity.ActivityId.ToString() }).ToList();
            }

            public UserActivityCreateViewModel() { }
    }
}


//in create: to show drop downs, you need two collections/dropdowns in the view model (select list)