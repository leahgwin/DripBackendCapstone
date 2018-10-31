using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using dripCapstone.Models;

namespace DripBackendCapstoneNSS.Models
{
    public class DripBackendCapstoneNSSContext : DbContext
    {
        public DripBackendCapstoneNSSContext (DbContextOptions<DripBackendCapstoneNSSContext> options)
            : base(options)
        {
        }

        public DbSet<dripCapstone.Models.User> User { get; set; }

        public DbSet<dripCapstone.Models.UserActivity> UserActivity { get; set; }
    }
}
