using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teacher_api.Domain.Entities.Organizations;

namespace teacher_api.Infrastructure.Persistence.Configurations.Organizations
{
	public class OrganizationUserRoleConfiguration : IEntityTypeConfiguration<OrganizationUserRole>
    {
        public void Configure(EntityTypeBuilder<OrganizationUserRole> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.Organization).WithMany(w => w.Users).HasForeignKey(h => h.OrganizationId);

            builder.HasOne(h => h.Role).WithMany().HasForeignKey(h => h.RoleId);

            builder.HasOne(h => h.User).WithMany().HasForeignKey(h => h.UserId);
        }
    }
}

