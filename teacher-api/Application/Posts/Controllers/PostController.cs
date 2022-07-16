using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using teacher_api.Application.Base.Controllers;
using teacher_api.Application.Posts.Commands.CreatePost;
using teacher_api.Application.Posts.Queries.GetPosts;

namespace teacher_api.Application.Posts.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ApiBaseController
    {
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> GetPosts([FromQuery] GetPostsQuery query)
        {
            return Ok(await Mediator.Send(query));
        }


        [Authorize]
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreatePostCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}

