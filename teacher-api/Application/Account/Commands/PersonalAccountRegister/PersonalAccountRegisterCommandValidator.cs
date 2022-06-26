using System;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Application.Account.Commands.PersonalAccountRegister
{
	public class PersonalAccountRegisterCommandValidator: AbstractValidator<PersonalAccountRegisterCommand>
	{
		public PersonalAccountRegisterCommandValidator(UserManager<ApplicationUser> userManager)
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
						return (await userManager.FindByEmailAsync(m)) == null;
					})
					.WithMessage("Email has been registered. Please try another one.");
				});
		}
	}
}

