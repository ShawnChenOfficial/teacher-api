using System;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Domain.Entities.Shared
{
	public abstract class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }

        public string CreatedBy { get; set; } = default!;

        public ApplicationUser? ApplicationUser { get; set; }
    }
}

