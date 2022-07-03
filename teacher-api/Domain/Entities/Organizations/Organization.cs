using teacher_api.Domain.Entities.Shared;

namespace teacher_api.Domain.Entities.Organizations
{
	public class Organization
	{
		public int Id { get; set; }

        public string OrganizationUniqueIdentifier { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string Email { get; set; } = default!;

        public string Phone { get; set; } = default!;

        public string Region { get; set; } = default!;

        public string Description { get; set; } = default!;

        public string BackgroundImagePath { get; set; } = default!;

        public string ProfileImagePath { get; set; } = default!;

        public Location Location { get; set; } = new Location();

        public bool Verified { get; set; }

        public List<OrganizationUserRole> Users { get; set; } = new List<OrganizationUserRole>();
    }
}

