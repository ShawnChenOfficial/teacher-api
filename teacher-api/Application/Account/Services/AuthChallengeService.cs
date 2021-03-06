using System;
using System.Security.Claims;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using teacher_api.Application.Base.Interface;
using teacher_api.Domain.Entities.Organizations;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Application.Account.Services
{
	public class AuthChallengeService : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AuthService _authService;
        private readonly IRepository<Organization> _orgRepo;

        public AuthChallengeService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AuthService authService, IRepository<Organization> orgRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
            _orgRepo = orgRepo;
        }

        public async Task<IActionResult> Challenge(HttpContext context)
        {
            var request = context.GetOpenIddictServerRequest();

            if (request == null)
            {
                return BadRequest("Unknown Reqeust");
            }

            if (request.IsRefreshTokenGrantType())
            {
                return await TryRefreshTokenAsync(context);
            }
            else if(request.IsPasswordGrantType())
            {
                return await TryGrantAccessToken(request);
            }
            else
            {
                // Return bad request if the request is not for password grant type
                return BadRequest(new OpenIdConnectResponse
                {
                    Error = OpenIdConnectConstants.Errors.UnsupportedGrantType,
                    ErrorDescription = "The specified grant type is not supported."
                });
            }
        }

        private async Task<IActionResult> TryRefreshTokenAsync(HttpContext context)
        {
            // Retrieve the claims principal stored in the refresh token.
            var info = await context.AuthenticateAsync(OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);

            // Retrieve the user profile corresponding to the refresh token.
            var user = await _userManager.GetUserAsync(info.Principal);

            if (user == null)
            {
                return _authService.InvalidRefreshToken();
            }

            if (user.OrganizationId.HasValue && !IsOrganizationVerified(user.OrganizationId.Value))
            {
                return _authService.UnverifiedOrganization();
            }

            // Ensure the user is still allowed to sign in.
            if (!await _signInManager.CanSignInAsync(user))
            {
                return _authService.BlockedUser();
            }
            else
            {
                return await _authService.RefreshToken(user);
            }
        }

        private async Task<IActionResult> TryGrantAccessToken(OpenIddictRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Username);

            if (user == null)
            {
                return _authService.InvalidCredencials();
            }

            if (user.OrganizationId.HasValue && !IsOrganizationVerified(user.OrganizationId.Value))
            {
                return _authService.UnverifiedOrganization();
            }

            // Validate the username/password parameters and ensure the account is not locked out.
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: true);

            if (!result.Succeeded)
            {
                return _authService.InvalidCredencials();
            }
            else
            {
                return await _authService.GrantAccessToken(user);
            }
        }

        private bool IsOrganizationVerified(int id)
        {
            var org = _orgRepo.Find(id);

            return org == null ? false : org.Verified;
        }
    }
}

