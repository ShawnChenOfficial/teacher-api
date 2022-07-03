using System;
namespace teacher_api.Domain.Entities.Shared
{
	public class Location
	{
		public string? Address { get; set; }

		public string? Suburb { get; set; }

		public string? City { get; set; }

		public int? PostCode { get; set; }
	}
}

