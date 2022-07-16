using System;
using teacher_api.Domain.Entities.Categories;
using teacher_api.Domain.Entities.Shared;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Domain.Entities.Posts
{
	public class Post: AuditableEntity
    {
		public Guid Id { get; set; } = Guid.NewGuid();

		public string Title { get; set; } = default!;

		public int CategoryId { get; set; }

		public Category? Category { get; set; }

		public string Description { get; set; } = default!;

		public DateTime StartDate { get; set; }

		public Location Location { get; set; } = new Location();
    }
}

