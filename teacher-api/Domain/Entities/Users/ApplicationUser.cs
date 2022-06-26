using System;
using Microsoft.AspNetCore.Identity;
using teacher_api.Domain.Entities.Organizations;

namespace teacher_api.Domain.Entities.Users
{
	public class ApplicationUser:IdentityUser
	{
		public string FirstName { get; set; } = default!;

		public string Lastname { get; set; } = default!;

		public string Title { get; set; } = default!;

		public UserGender Gender { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public string? OrganizationId { get; set; }

		public Organization? Organization { get; set; }
	}

	public enum UserGender
    {
		Female,
		Male,
		Other
    }
}

