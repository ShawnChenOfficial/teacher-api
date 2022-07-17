using System.Security.Claims;
using AspNet.Security.OpenIdConnect.Primitives;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using teacher_api.Domain.Entities.Users;
using static AspNet.Security.OpenIdConnect.Primitives.OpenIdConnectConstants;

namespace teacher_api.Application.Account.Services
{
    public class AuthService : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> RefreshToken(ApplicationUser user)
        {
            // Create a new ClaimsPrincipal containing the claims that
            // will be used to create an id_token, a token or a code.
            var principal = await _signInManager.CreateUserPrincipalAsync(user);

            principal.SetClaim(Claims.Username, user.UserName);

            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);
            }

            principal.SetScopes(OpenIdConnectConstants.Scopes.OfflineAccess);

            principal.AddIdentity(new ClaimsIdentity("userId", user.Id, ClaimValueTypes.String));

            var properties = new AuthenticationProperties();
            var roles = await _userManager.GetRolesAsync(user);

            // PropertyTypes.String is required for the value to be returned in the endpoint
            properties.SetParameter("userId", user.Id);
            properties.SetParameter("name", user.UserName);
            properties.SetParameter("roles", JsonConvert.SerializeObject(roles));

            return SignIn(principal, properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        public IActionResult BlockedUser()
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string?>
            {
                [Properties.Error] = Errors.InvalidGrant,
                [Properties.ErrorDescription] = "The user is no longer allowed to sign in."
            });

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        public IActionResult InvalidRefreshToken()
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string?>
            {
                [Properties.Error] = Errors.InvalidGrant,
                [Properties.ErrorDescription] = "The refresh token is no longer valid."
            });

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        public async Task<IActionResult> GrantAccessToken(ApplicationUser user)
        {
            // Create a new ClaimsPrincipal containing the claims that
            // will be used to create an id_token, a token or a code.
            var principal = await _signInManager.CreateUserPrincipalAsync(user);

            principal.SetClaim(Claims.Username, user.UserName);

            foreach (var claim in principal.Claims)
            {
                claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);
                claim.SetDestinations(Destinations.AccessToken, Destinations.IdentityToken);
            }

            principal.SetScopes(OpenIdConnectConstants.Scopes.OfflineAccess);

            principal.AddIdentity(new ClaimsIdentity("userId", user.Id, ClaimValueTypes.String));

            var properties = new AuthenticationProperties();
            var roles = await _userManager.GetRolesAsync(user);

            // PropertyTypes.String is required for the value to be returned in the endpoint
            properties.SetParameter("userId", user.Id);
            properties.SetParameter("name", user.UserName);
            properties.SetParameter("roles", JsonConvert.SerializeObject(roles));

            if (user.OrganizationId.HasValue)
            {
                properties.SetParameter("organizationId", user.OrganizationId);
            }

            return SignIn(principal, properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        public IActionResult InvalidCredencials()
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string?>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                                    "The username/password couple is invalid."
            });

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

        public IActionResult UnverifiedOrganization()
        {
            var properties = new AuthenticationProperties(new Dictionary<string, string?>
            {
                [OpenIddictServerAspNetCoreConstants.Properties.Error] = Errors.InvalidGrant,
                [OpenIddictServerAspNetCoreConstants.Properties.ErrorDescription] =
                                    "Trying to login the admin account for an unverified orgniaztion. Please contact with us to verify your organization."
            });

            return Forbid(properties, OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
        }

    }
}

