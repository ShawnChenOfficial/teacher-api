using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Posts.Models;
using teacher_api.Domain.Entities.Posts;
using teacher_api.Domain.Entities.Shared;

namespace teacher_api.Application.Posts.Commands.CreatePost
{
	public record CreatePostCommand: IRequest<PostDto>
	{
        public string Title { get; set; } = default!;
        public int CategoryId { get; set; }
        public string Description { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public Location Location { get; set; } = new Location();
	}

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, PostDto>
    {
        private readonly IRepository<Post> repo;

        public CreatePostCommandHandler(IRepository<Post> repo)
        {
            this.repo = repo;
        }

        public Task<PostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var post = new Post
            {
                Title = request.Title,
                CategoryId = request.CategoryId,
                Description = request.Description,
                StartDate = request.StartDate,
                Location = request.Location
            };

            repo.Add(post);

            var dto = repo.Get().Where(w => post.Id == w.Id).Select(s => new PostDto
            {
                Id = s.Id,
                Title = s.Title,
                CategoryId = s.CategoryId,
                CategoryName = s.Category!.Name,
                Description = s.Description,
                StartDate = s.StartDate,
                Location = new Location
                {
                     Address = s.Location.Address,
                     Suburb = s.Location.Suburb,
                     City = s.Location.City,
                     PostCode = s.Location.PostCode,
                },
            }).First();

            return Task.FromResult(dto);
        }
    }
}

