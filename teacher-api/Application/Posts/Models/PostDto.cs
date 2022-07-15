using System;
using teacher_api.Domain.Entities.Shared;

namespace teacher_api.Application.Posts.Models
{
	public class PostDto
    {
        public Guid Id { get; set; } = default!;

        public string Title { get; set; } = default!;

        public int CategoryId { get; set; }

        public string CategoryName { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime StartDate { get; set; }

        public string UserId { get; set; } = default!;

        public DateTime CreatedBy { get; set; }

        public Location Location { get; set; }
    }
}

