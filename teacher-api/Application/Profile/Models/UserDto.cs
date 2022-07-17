using System;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Application.Profile.Models
{
	public class UserDto
	{
		public string Id { get; set; } = default!;

        public UserGender Gender { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public int? OrganizationId { get; set; }

		public string? OrganizationName { get; set; }

		public string Email { get; set; } = default!;

        public string? Phone { get; set; }

		public string? ProfileImg { get; set; }

        public string? BackgroundImg { get; set; }
    }
}

