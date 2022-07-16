using System;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using teacher_api.Domain.Entities.Shared;
using teacher_api.Domain.Entities.Users;
using teacher_api.Infrastructure.Persistence.Configurations.DataSeeder;
using teacher_api.Infrastructure.Persistence.Configurations.Users;
using teacher_api.Infrastructure.Persistence.Interfaces;

namespace teacher_api.Domain.Configurations
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IUserService userService;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IUserService userService) : base(options)
        {
            this.userService = userService;
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()).SeedData();

            base.OnModelCreating(mb);
        }

        public override int SaveChanges()
        {
            SetAuditableEntities();

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken token)
        {
            SetAuditableEntities();

            return await base.SaveChangesAsync(token);
        }

        private void SetAuditableEntities()
        {
            foreach (var data in ChangeTracker.Entries<AuditableEntity>())
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedAt = DateTime.Now;
                    data.Entity.CreatedBy = userService.UserId;
                }
            }
        }
    }
}

