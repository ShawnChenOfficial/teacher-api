using System;
namespace teacher_api.Domain.Entities.Shared
{
	public class Location
	{
		public string Number { get; set; } = default!;

		public string Street { get; set; } = default!;

		public string Suburb { get; set; } = default!;

		public string City { get; set; } = default!;

		public string Region { get; set; } = default!;
	}
}

