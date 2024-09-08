using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyAssignment_Model;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAssignment_DataAccess
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<State> States { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Customer_Info> Customer_Infos { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            builder.Entity<Gender>().HasData(
                new Gender { Id = 1, Name = "Male" },
                new Gender { Id = 2, Name = "Female" },
                new Gender { Id = 3, Name = "Other" }
                );
            builder.Entity<State>().HasData(
                new State { Id = 1, Name = "Jharkhand" },
                new State { Id = 2, Name = "Uttar Pradesh" },
                new State { Id = 3, Name = "West Bengal" }
                );
            builder.Entity<District>().HasData(
                new District { Id = 1, Name = "Bokaro", StateId = 1 },
                new District { Id = 2, Name = "Dhanbad", StateId = 1 },
                new District { Id = 3, Name = "East Singhbhum", StateId = 1 },
                new District { Id = 4, Name = "Ranchi", StateId = 1 },
                new District { Id = 5, Name = "Agra", StateId = 2 },
                new District { Id = 6, Name = "Aligarh", StateId = 2 },
                new District { Id = 7, Name = "Ghaziabad", StateId = 2 },
                new District { Id = 8, Name = "Bankura", StateId = 3 },
                new District { Id = 9, Name = "Howrah", StateId = 3 },
                new District { Id = 10, Name = "Kolkata", StateId = 3 }
                );
        }
    }
}
