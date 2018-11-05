using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DripBackendCapstoneNSS.Models;
using Microsoft.AspNetCore.Identity;

namespace DripBackendCapstoneNSS.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<DripBackendCapstoneNSS.Models.User> User { get; set; }
        public DbSet<DripBackendCapstoneNSS.Models.Activity> Activity { get; set; }
        public DbSet<DripBackendCapstoneNSS.Models.UserActivity> UserActivity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            User user = new User
            {
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                Neighborhood = "Camps Bay",
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            var passwordHash = new PasswordHasher<User>();
            user.PasswordHash = passwordHash.HashPassword(user, "Admin8*");
            modelBuilder.Entity<User>().HasData(user);



            modelBuilder.Entity<UserActivity>().HasData(
          new UserActivity()
          {
              UserActivityId = 1,
              UserId = user.Id,
              ActivityId = 1,
              Date = DateTime.Now,
              Count = 1,
          },
          new UserActivity()
          {
              UserActivityId = 2,
              UserId = user.Id,
              ActivityId = 4,
              Date = DateTime.Now,
              Count = 3,
          },
          new UserActivity()
          {
              UserActivityId = 3,
              UserId = user.Id,
              ActivityId = 8,
              Date = DateTime.Now,
              Count = 3,
          }
          );

            modelBuilder.Entity<Activity>().HasData(
            new Activity()
            {
                ActivityId = 1,
                Name = "Flush",
                Liters = 10,
            },
            new Activity()
            {
                ActivityId = 2,
                Name = "Bath",
                Liters = 150,
            },
            new Activity()
            {
                ActivityId = 3,
                Name = "Five Minute Shower",
                Liters = 55,
            },
            new Activity()
            {
                ActivityId = 4,
                Name = "Sponge Bath",
                Liters = 1,
            },
            new Activity()
            {
                ActivityId = 5,
                Name = "Brush Teeth",
                Liters = 1,
            },
            new Activity()
            {
                ActivityId = 6,
                Name = "Wash Dishes By Hand",
                Liters = 10,
            },
            new Activity()
            {
                ActivityId = 7,
                Name = "Run Dishwasher",
                Liters = 30,
            },
            new Activity()
            {
                ActivityId = 8,
                Name = "Washing Machine Load",
                Liters = 75,
            },
            new Activity()
            {
                ActivityId = 9,
                Name = "Cooking",
                Liters = 1,
            },
            new Activity()
            {
                ActivityId = 10,
                Name = "Bath",
                Liters = 150,
            },
            new Activity()
            {
                ActivityId = 11,
                Name = "Pet Water Bowl",
                Liters = 1,
            },
            new Activity()
            {
                ActivityId = 12,
                Name = "Wash Hands or Face",
                Liters = 1,
            }
            );

        }
    }
}



    //ask jisie about:
    //1) date dataType in UserActivity (and other models)
    //2) I think I need a new migration now that I've added this seeding
    //3) on models: see icollection or Activity Activity option for FK?
    //4) see createView for question about count?