using System;
using MediatR;
using teacher_api.Application.Base.Interface;
using teacher_api.Application.Categories.Models;
using teacher_api.Domain.Entities.Categories;

namespace teacher_api.Application.Categories.Commands.RemoveCategory
{
	public record RemoveCategoryCommand: IRequest<bool>
	{
        public Guid Id { get; set; }
	}

    public class RemoveCategoryCommandHandler : IRequestHandler<RemoveCategoryCommand, bool>
    {
        private readonly IRepository<Category> categoryRepo;

        public RemoveCategoryCommandHandler(IRepository<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public Task<bool> Handle(RemoveCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = categoryRepo.Find(request.Id)!;

            category.Archived = true;

            categoryRepo.Update(category);

            return Task.FromResult(true);
        }
    }
}

