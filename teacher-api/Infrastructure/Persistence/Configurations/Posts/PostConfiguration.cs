using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teacher_api.Domain.Entities.Posts;

namespace teacher_api.Infrastructure.Persistence.Configurations.Posts
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(h => h.Id);

            builder.HasOne(h => h.Category).WithMany(w => w.Posts);

            builder.HasOne(h => h.ApplicationUser).WithMany();
        }
    }
}

