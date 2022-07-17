using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Profile.Models;
using teacher_api.Domain.Entities.Users;
using teacher_api.Infrastructure.Persistence.Interfaces;

namespace teacher_api.Application.Profile.Queries.GetProfile
{
	public record GetProfileQuery:IRequest<UserDto>
	{
	}

    public class GetProfileQueryHandler : IRequestHandler<GetProfileQuery, UserDto>
    {
        private readonly IUserService userService;
        private readonly IRepository<ApplicationUser> repo;

        public GetProfileQueryHandler(IRepository<ApplicationUser> repo, IUserService userService)
        {
            this.repo = repo;
            this.userService = userService;
        }

        public Task<UserDto> Handle(GetProfileQuery request, CancellationToken cancellationToken)
        {
            var dto = repo.Get().Where(w => w.Id == userService.UserId).Select(s => new UserDto
            {
                Id = s.Id,
                Gender = s.Gender,
                FirstName = s.FirstName,
                LastName = s.Lastname,
                Email = s.Email,
                OrganizationId = s.OrganizationId,
                OrganizationName = s.Organization == null ? null : s.Organization.Name,
                Phone = s.PhoneNumber,
                ProfileImg = s.ProfileImagePath,
                BackgroundImg = s.BackgroundImagePath
            }).First();

            return Task.FromResult(dto);
        }
    }
}

