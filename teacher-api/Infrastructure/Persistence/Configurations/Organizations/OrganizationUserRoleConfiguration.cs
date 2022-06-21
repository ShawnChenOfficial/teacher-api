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
            builder.HasKey(h => new { h.UserId, h.RoleId, h.OrganizationId });
        }
    }
}

