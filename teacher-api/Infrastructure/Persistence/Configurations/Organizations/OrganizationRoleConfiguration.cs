using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teacher_api.Domain.Entities.Organizations;

namespace teacher_api.Infrastructure.Persistence.Configurations.Organizations
{
	public class OrganizationRoleConfiguration : IEntityTypeConfiguration<OrganizationRole>
    {
        public void Configure(EntityTypeBuilder<OrganizationRole> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}

