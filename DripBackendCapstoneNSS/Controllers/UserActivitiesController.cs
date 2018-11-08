
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DripBackendCapstoneNSS.Data;
using DripBackendCapstoneNSS.Models;
using Microsoft.AspNetCore.Identity;
using System.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using DripBackendCapstoneNSS.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace DripBackendCapstoneNSS.Controllers
{
    public class UserActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        //need all of this for identity user
        public UserManager<User> _userManager;

        public UserActivitiesController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        private Task<User> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: UserActivities
        [Authorize]

        public async Task<IActionResult> Index()
        {
            User user = await GetCurrentUserAsync();
            var viewModel = new UserActivityListViewModel();

            var userActivities = await _context.UserActivity
                .Where(u => u.User.Id == user.Id)
                .Include(u => u.Activity)
                .Include(u => u.User)
                .OrderByDescending(u => u.Date)
                .ToListAsync();
            //loop through useractivities with linq statement to call multiplication method
            foreach (UserActivity u in userActivities)
            {
                u.SetLiterTotal();
            }
            viewModel.UserActivities = userActivities;
            return View(viewModel); 


        }

        // GET: UserActivities/Details/5
        [Authorize]

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivity
                 .Include(u => u.Activity)
                 .Include(u => u.User)
                 .FirstOrDefaultAsync(m => m.UserActivityId == id);

            if (userActivity == null)
            {
                return NotFound();
            }

            return View(userActivity);
        }

        // GET: UserActivities/Create
        [Authorize]

        public IActionResult Create()
        {
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "Name");
            ViewData["Id"] = new SelectList(_context.User, "Id", "Id");
            return View();
        }

        // POST: UserActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserActivityId,Date,Count,Id,ActivityId")] UserActivity userActivity)
        {
            if (ModelState.IsValid)
            {
                //get current user and set FK for user on user activity to their ID
                User user = await GetCurrentUserAsync();
                userActivity.User = user;
                _context.Add(userActivity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "Name", userActivity.ActivityId);
            ViewData["Id"] = new SelectList(_context.User, "Id", "Id", userActivity.Id);
            return View(userActivity);
        }

        // GET: UserActivities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivity.FindAsync(id);
            if (userActivity == null)
            {
                return NotFound();
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "Name", userActivity.ActivityId);
            ViewData["Id"] = new SelectList(_context.User, "Id", "Id", userActivity.Id);
            return View(userActivity);
        }

        // POST: UserActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserActivityId,Date,Count,Id,ActivityId")] UserActivity userActivity)
        {
            //get current user
            User user = await GetCurrentUserAsync();
            userActivity.User = user;


            if (id != userActivity.UserActivityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {


                try
                {
                    _context.Update(userActivity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserActivityExists(userActivity.UserActivityId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ActivityId"] = new SelectList(_context.Activity, "ActivityId", "Name", userActivity.ActivityId);
            ViewData["Id"] = new SelectList(_context.User, "Id", "Id", userActivity.Id);
            return View(userActivity);
        }

        // GET: UserActivities/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userActivity = await _context.UserActivity
                .Include(u => u.Activity)
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserActivityId == id);
            if (userActivity == null)
            {
                return NotFound();
            }

            return View(userActivity);
        }

        // POST: UserActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userActivity = await _context.UserActivity.FindAsync(id);
            _context.UserActivity.Remove(userActivity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserActivityExists(int id)
        {
            return _context.UserActivity.Any(e => e.UserActivityId == id);
        }
    }
}
