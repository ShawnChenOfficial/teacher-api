using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Posts.Models;
using teacher_api.Domain.Entities.Posts;

namespace teacher_api.Application.Posts.Queries.GetPosts
{
    public record GetPostsQuery : IRequest<List<PostDto>>
    {
        public int CategoryId { get; set; }
    }

    public class GetPostsQueryHandler : IRequestHandler<GetPostsQuery, List<PostDto>>
    {
        private readonly IRepository<Post> postRepo;

        public GetPostsQueryHandler(IRepository<Post> postRepo)
        {
            this.postRepo = postRepo;
        }

        public Task<List<PostDto>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
        {
            var result = postRepo
                .Get()
                .Where(w => w.CategoryId == request.CategoryId)
                .OrderByDescending(o => o.CreatedBy)
                .Select(s => new PostDto
                {
                    CategoryId = s.CategoryId,
                    CategoryName = s.Category.Name,
                    StartDate = s.StartDate,
                    CreatedBy = s.CreatedBy,
                    Description = s.Description,
                    Id = s.Id,
                    Title = s.Title,
                    UserId = s.UserId
                }).ToList();

            return Task.FromResult(result);
        }
    }
}

