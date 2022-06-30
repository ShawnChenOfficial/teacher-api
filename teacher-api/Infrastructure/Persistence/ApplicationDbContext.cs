using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using teacher_api.Domain.Entities.Users;
using teacher_api.Infrastructure.Persistence.Configurations.DataSeeder;
using teacher_api.Infrastructure.Persistence.Configurations.Users;

namespace teacher_api.Domain.Configurations
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        /// <summary>
        /// Fluent definitions
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()).SeedData();

            base.OnModelCreating(mb);
        }
    }
}

