using System;
using Microsoft.AspNetCore.Mvc;
using teacher_api.Application.Base.Controllers;
using teacher_api.Application.Organizations.Queries.SearchOrganizations;

namespace teacher_api.Application.Organizations.Controllers
{
    [Route("api/[controller]")]
    public class OrganizationController : ApiBaseController
    {
        [HttpGet]
        [Route("search")]
        public async Task<IActionResult> Search([FromQuery] SearchOrganizationQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
	}
}

