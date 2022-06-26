using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teacher_api.Domain.Entities.Categories;

namespace teacher_api.Infrastructure.Persistence.Configurations.Categories
{
	public class CategoryConfigration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(h => h.Id);
        }
    }
}

