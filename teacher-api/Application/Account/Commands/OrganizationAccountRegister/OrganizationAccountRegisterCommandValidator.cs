using System;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using teacher_api.Application.Base.Interface;
using teacher_api.Domain.Entities.Organizations;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Application.Account.Commands.OrganizationAccountRegister
{
    public class OrganizationAccountRegisterCommandValidator : AbstractValidator<OrganizationAccountRegisterCommand>
    {
        public OrganizationAccountRegisterCommandValidator(UserManager<ApplicationUser> userManager, IRepository<Organization> organizationRepo)
        {
            RuleFor(r => r)
                .Must(m =>
                {
                    return m.Password == m.Re_Password;
                })
                .WithMessage("Unmatched passwords")
                .DependentRules(() =>
                {
                    RuleFor(r => r.Email)
                    .MustAsync(async (m, token) =>
                    {
                        return await userManager.FindByEmailAsync(m) == null;
                    })
                    .WithMessage("Email has been registered. Please try another one.")
                    .DependentRules(() =>
                    {
                        RuleFor(r => r.OrganizationUniqueIdentifier)
                        .Must(m =>
                        {
                            return organizationRepo.Get().Where(w => w.OrganizationUniqueIdentifier == m && w.Verified).Count() == 0;
                        })
                        .WithMessage("Your organization has registerd with us, please contact with your organization");
                    });
                });
        }
    }
}

