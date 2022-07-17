using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Server.AspNetCore;
using teacher_api.Application.Base.Controllers;
using teacher_api.Application.Categories.Commands.CreateCategory;
using teacher_api.Application.Categories.Commands.RemoveCategory;
using teacher_api.Application.Categories.Commands.UpdateCategory;
using teacher_api.Application.Categories.Queries.GetCategories;
using teacher_api.Application.Profile.Queries.GetProfile;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teacher_api.Application.Profile.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProfileController : ApiBaseController
    {
        [Authorize]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetProfileQuery()));
        }
    }
}

