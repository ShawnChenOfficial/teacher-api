using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using teacher_api.Application.Base.Controllers;
using teacher_api.Application.Categories.Commands.CreateCategory;
using teacher_api.Application.Categories.Queries.GetCategories;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace teacher_api.Application.Categories.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ApiBaseController
    {
        // GET: /<controller>/
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get(GetCategoriesQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}

