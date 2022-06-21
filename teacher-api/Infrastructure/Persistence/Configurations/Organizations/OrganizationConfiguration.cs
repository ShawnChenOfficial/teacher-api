using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teacher_api.Domain.Entities.Organizations;

namespace teacher_api.Infrastructure.Persistence.Configurations.Organizations
{
	public class OrganizationConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(h => h.Id);
            builder.OwnsOne(o => o.Location);
            builder.HasMany(h => h.Users).WithOne();
        }
    }
}

