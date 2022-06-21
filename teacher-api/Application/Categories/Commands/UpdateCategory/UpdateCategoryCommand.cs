using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Categories.Models;
using teacher_api.Domain.Entities.Categories;

namespace teacher_api.Application.Categories.Commands.UpdateCategory
{
	public record UpdateCategoryCommand: IRequest<CategoryDto>
	{
        public Guid Id { get; set; }
		public string Name { get; set; } = default!;
	}

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryDto>
    {
        private readonly IRepository<Category> categoryRepo;

        public UpdateCategoryCommandHandler(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public Task<CategoryDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepo.Find(request.Id)!;

            category.Name = request.Name;

            categoryRepo.Update(category);

            return Task.FromResult(new CategoryDto { Id = category.Id, Name = category.Name });
        }
    }
}

