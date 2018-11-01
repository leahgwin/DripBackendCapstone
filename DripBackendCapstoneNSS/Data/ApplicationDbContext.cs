using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using dripCapstone.Models;

namespace DripBackendCapstoneNSS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<dripCapstone.Models.User> User { get; set; }
        public DbSet<dripCapstone.Models.Activity> Activity { get; set; }
        public DbSet<dripCapstone.Models.UserActivity> UserActivity { get; set; }
    }
}
