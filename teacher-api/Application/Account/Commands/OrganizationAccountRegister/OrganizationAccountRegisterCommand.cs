using System;
using MediatR;
using Microsoft.AspNetCore.Identity;
using teacher_api.Application.Base.Interface;
using teacher_api.Domain.Entities.Organizations;
using teacher_api.Domain.Entities.Shared;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Application.Account.Commands.OrganizationAccountRegister
{
	public record OrganizationAccountRegisterCommand : IRequest<bool>
    {
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;

        public string Re_Password { get; set; } = default!;

        public string UserName { get; set; } = default!;

        public string OrganizationUniqueIdentifier { get; set; } = default!;

        public string OrganizationName { get; set; } = default!;

        public string? OrganizationEmail { get; set; }

        public string? OrganizationPhone { get; set; }

        public string OrganizationRegion { get; set; } = default!;

        public string OrganizationAddress { get; set; } = default!;

        public string OrganizationSuburb { get; set; } = default!;

        public string OrganizationCity { get; set; } = default!;

        public int OrganizationPostCode { get; set; }
    }

    public class OrganizationAccountRegisterCommandHandler : IRequestHandler<OrganizationAccountRegisterCommand, bool>
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Organization> orgRepo;
        private readonly IRepository<OrganizationUserRole> orgUserRoleRepo;
        private readonly IRepository<OrganizationRole> orgRoleRepo;

        public OrganizationAccountRegisterCommandHandler(UserManager<ApplicationUser> userManager, IRepository<OrganizationRole> orgRoleRepo, IRepository<OrganizationUserRole> orgUserRoleRepo, IRepository<Organization> orgRepo)
        {
            this.userManager = userManager;
            this.orgRoleRepo = orgRoleRepo;
            this.orgUserRoleRepo = orgUserRoleRepo;
            this.orgRepo = orgRepo;
        }

        public async Task<bool> Handle(OrganizationAccountRegisterCommand request, CancellationToken cancellationToken)
        {
            // create organization
            var organization = new Organization
            {
                Name = request.OrganizationName,
                OrganizationUniqueIdentifier = request.OrganizationUniqueIdentifier,
                Region = request.OrganizationRegion,
                BackgroundImagePath = "",
                Description = "",
                ProfileImagePath = "",
                Email = request.OrganizationEmail,
                Phone = request.OrganizationPhone,
                Location = new Location
                {
                    Address = request.OrganizationAddress,
                    Suburb = request.OrganizationSuburb,
                    City = request.OrganizationCity,
                    PostCode = request.OrganizationPostCode,
                }
            };

            orgRepo.Add(organization);

            var userToCreate = new ApplicationUser
            {
                UserName = request.UserName,
                Email = request.Email,
                FirstName = request.OrganizationName,
                Lastname = request.OrganizationName,
                Gender = UserGender.Other,
                PhoneNumber = "",
                Title = "",
                BackgroundImagePath = "",
                ProfileImagePath = "",
                Location = new Location(),
                OrganizationId = organization.Id,
            };

            userToCreate.PasswordHash = userManager.PasswordHasher.HashPassword(userToCreate, request.Password);

            await userManager.CreateAsync(userToCreate);

            await userManager.AddToRoleAsync(userToCreate, UserRoles.User.ToString());

            var adminRoleId = orgRoleRepo.Get().Where(w => w.Role == "Admin").First().Id;

            orgUserRoleRepo.Add(new OrganizationUserRole
            {
                OrganizationId = organization.Id,
                RoleId = adminRoleId,
                UserId = userToCreate.Id
            });
            // Send Confirmation Email
            var validationToken = await userManager.CreateSecurityTokenAsync(userToCreate);


            return true;
        }
    }
}

