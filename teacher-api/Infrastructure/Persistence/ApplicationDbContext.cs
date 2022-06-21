using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using teacher_api.Domain.Entities.Users;
using teacher_api.Infrastructure.Persistence.Configurations.Users;

namespace teacher_api.Domain.Configurations
{
	public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
		{
		}

        /// <summary>
        /// Fluent definitions
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);

            mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

