using System;
namespace teacher_api.Domain.Entities.Organizations
{
	public class OrganizationRole
	{
		/// <summary>
		/// GUID
		/// </summary>
		public string Id { get; set; } = default!;

		public string Role { get; set; } = default!;
	}
}

