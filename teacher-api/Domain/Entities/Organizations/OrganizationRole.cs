using System;
namespace teacher_api.Domain.Entities.Organizations
{
	public class OrganizationRole
	{
		/// <summary>
		/// GUID
		/// </summary>
		public Guid Id { get; set; }

		public string Role { get; set; } = default!;
	}
}

