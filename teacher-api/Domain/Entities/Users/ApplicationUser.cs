using System;
using Microsoft.AspNetCore.Identity;
using teacher_api.Domain.Entities.Organizations;

namespace teacher_api.Domain.Entities.Users
{
	public class ApplicationUser:IdentityUser
	{
		public string FirstName { get; set; } = default!;

		public string Lastname { get; set; } = default!;

		public bool OrganizationUser { get; set; }

		public string? OrganizationId { get; set; }

		public Organization? Organization { get; set; }
	}
}

