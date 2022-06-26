using System;
using teacher_api.Domain.Entities.Posts;

namespace teacher_api.Domain.Entities.Categories
{
	public class Category
	{
		public int Id { get; set; }

		public string Name { get; set; } = default!;

		public bool Archived { get; set; }

		public List<Post> Posts { get; set; } = new List<Post>();
	}
}

