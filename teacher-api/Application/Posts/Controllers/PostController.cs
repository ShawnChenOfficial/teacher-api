using System;
using Microsoft.AspNetCore.Mvc;
using teacher_api.Application.Base.Controllers;
using teacher_api.Application.Posts.Queries.GetPosts;

namespace teacher_api.Application.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ApiBaseController
    {
        /// <summary>
        /// get posts by single cateogry
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

    }
}

