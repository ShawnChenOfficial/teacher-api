using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Categories.Models;
using teacher_api.Domain.Entities.Categories;

namespace teacher_api.Application.Categories.Queries.GetCategories
{
	public record GetCategoriesQuery: IRequest<List<CategoryGet>>
	{
	}

    public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<CategoryGet>>
    {
        private readonly IRepository<Category> categoryRepo;

        public GetCategoriesQueryHandler(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public Task<List<CategoryGet>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var data = categoryRepo.Get()
                .Where(w => !w.Archived)
                .Select(s => new CategoryGet
                {
                    Id = s.Id,
                    Name = s.Name
                }).ToList();

            return Task.FromResult(data);
        }
    }
}

