using System;
using Microsoft.AspNetCore.Mvc;

namespace teacher_api.Application.Base.Queries
{
	public record SearchQueryBase
	{
        [FromQuery]
		public string? Term { get; set; }
	}
}

