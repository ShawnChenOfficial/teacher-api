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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teacher_api.Application.Categories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ApiBaseController
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetCategoriesQuery()));
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpPatch]
        public async Task<IActionResult> Update(UpdateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Authorize(Roles = "Admin")]
        [Route("")]
        [HttpDelete]
        public async Task<IActionResult> Remove(RemoveCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

