using System;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Domain.Entities.Organizations
{
	public class OrganizationUserRole
	{
		public string UserId { get; set; } = default!;

		public ApplicationUser? User { get; set; }

		public string RoleId { get; set; } = default!;

		public OrganizationRole? Role { get; set; }

		public int OrganizationId { get; set; }

		public Organization? Organization { get; set; }
	}
}

