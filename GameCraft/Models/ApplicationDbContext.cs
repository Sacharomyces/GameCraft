using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GameCraft.Models
{
        public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
        {
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Boardgame> Boardgames { get; set; }
            public DbSet<MembershipType> MembershipTypes { get; set; }
            public DbSet<Genre> Genres { get; set; }
            public DbSet<Rental> Rentals { get; set; }

            

            public ApplicationDbContext()
                : base("DefaultConnection", throwIfV1Schema: false)
            {
            }

            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
        }
}

