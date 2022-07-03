using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Base.Queries;
using teacher_api.Application.Organizations.Dtos;
using teacher_api.Domain.Entities.Organizations;
using teacher_api.Domain.Entities.Shared;

namespace teacher_api.Application.Organizations.Queries.SearchOrganizations
{
	public record SearchOrganizationQuery: SearchQueryBase, IRequest<List<OrganizationDto>>
	{

	}

    public class SearchOrganizationQueryHandler : IRequestHandler<SearchOrganizationQuery, List<OrganizationDto>>
    {
        private readonly IRepository<Organization> repo;

        public SearchOrganizationQueryHandler(IRepository<Organization> repo)
        {
            this.repo = repo;
        }

        public Task<List<OrganizationDto>> Handle(SearchOrganizationQuery request, CancellationToken cancellationToken)
        {
            var query = repo.Get();

            if (!string.IsNullOrWhiteSpace(request.Term))
            {
                query = query.Where(w => w.Name.ToLower().Contains(request.Term.ToLower()));
            }

            var result = query.Select(s => new OrganizationDto
            {
                OrganizationId = s.Id,
                OrganizationUniqueIdentifier = s.OrganizationUniqueIdentifier,
                OrganizationName = s.Name,
                ProfileImagePath = s.ProfileImagePath,
                Location = s.Location == null ? new Location() : new Location
                {
                    Address = s.Location.Address,
                    Suburb = s.Location.Suburb,
                    City = s.Location.City,
                    PostCode = s.Location.PostCode
                },
                Verified = s.Verified,
                UserCount = s.Users.Count(),
            }).ToList();

            return Task.FromResult(result);
        }
    }
}

