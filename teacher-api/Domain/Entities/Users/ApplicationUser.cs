using System;
using Microsoft.AspNetCore.Identity;
using teacher_api.Domain.Entities.Organizations;
using teacher_api.Domain.Entities.Shared;

namespace teacher_api.Domain.Entities.Users
{
	public class ApplicationUser:IdentityUser
	{
		public string FirstName { get; set; } = default!;

		public string Lastname { get; set; } = default!;

		public string Title { get; set; } = default!;

		public UserGender Gender { get; set; } = default!;

        public DateTime DateOfBirth { get; set; }

        public int? OrganizationId { get; set; }

		public Organization? Organization { get; set; }

		public string BackgroundImagePath { get; set; } = default!;

		public string ProfileImagePath { get; set; } = default!;

		public Location? Location { get; set; }
	}

	public enum UserGender
    {
		Female,
		Male,
		Other
    }
}

