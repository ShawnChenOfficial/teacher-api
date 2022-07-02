using System;
using teacher_api.Domain.Entities.Shared;

namespace teacher_api.Application.Organizations.Dtos
{
	public class OrganizationDto
	{
		public int OrganizationId { get; set; }

        public string OrganizationUniqueIdentifier { get; set; } = default!;

		public string OrganizationName { get; set; } = default!;

        public string ProfileImagePath { get; set; } = default!;

        public Location? Location { get; set; }

        public bool Verified { get; set; }

        public int UserCount { get; set; }
    }
}

