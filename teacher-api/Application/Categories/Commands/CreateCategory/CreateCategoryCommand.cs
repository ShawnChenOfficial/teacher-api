using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Categories.Models;
using teacher_api.Domain.Entities.Categories;

namespace teacher_api.Application.Categories.Commands.CreateCategory
{
	public record CreateCategoryCommand: IRequest<CategoryDto>
	{
		public string Name { get; set; } = default!;
	}

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryDto>
    {
        private readonly IRepository<Category> categoryRepo;

        public CreateCategoryCommandHandler(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public Task<CategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Name = request.Name
            };

            categoryRepo.Add(category);

            return Task.FromResult(new CategoryDto { Id = category.Id, Name = category.Name });
        }
    }
}

