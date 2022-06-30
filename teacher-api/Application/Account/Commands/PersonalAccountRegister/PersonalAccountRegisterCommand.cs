using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using teacher_api.Domain.Entities.Shared;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Application.Account.Commands.PersonalAccountRegister
{
	public record PersonalAccountRegisterCommand: IRequest<bool>
	{
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string Re_Password { get; set; } = default!;

        public string UserName { get; set; } = default!;

        public string FirstName { get; set; } = default!;

        public string LastName { get; set; } = default!;

        public string Title { get; set; } = default!;

        public UserGender Gender { get; set; }

        public string Phone { get; set; } = default!;

        public string City { get; set; } = default!;
    }

    public class PersonalAccountRegisterCommandHandler : IRequestHandler<PersonalAccountRegisterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public PersonalAccountRegisterCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<bool> Handle(PersonalAccountRegisterCommand request, CancellationToken cancellationToken)
        {
            var userToCreate = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.FirstName,
                Lastname = request.LastName,
                Gender = request.Gender,
                PhoneNumber = request.Phone,
                Title = request.Title,
                BackgroundImagePath = "",
                ProfileImagePath = "",
                Location = new Location()
                {
                    City = request.City
                }
            };

            userToCreate.PasswordHash = userManager.PasswordHasher.HashPassword(userToCreate, request.Password);

            await userManager.CreateAsync(userToCreate);

            await userManager.AddToRoleAsync(userToCreate, UserRoles.User.ToString());

            var validationToken = await userManager.CreateSecurityTokenAsync(userToCreate);

            // Send Confirmation Email

            return true;
        }
    }
}

