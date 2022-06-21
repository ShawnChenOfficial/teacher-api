using System;
using teacher_api.Domain.Entities.Categories;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Domain.Entities.Posts
{
	public class Post
	{
		public string Id { get; set; } = default!;

		public string Title { get; set; } = default!;

		public int CategoryId { get; set; }

		public Category? Category { get; set; }

		public string Description { get; set; } = default!;

		public DateTime StartDate { get; set; }

        public string UserId { get; set; } = default!;

        public ApplicationUser? ApplicationUser { get; set; }

        public DateTime CreatedBy { get; set; }
    }
}

