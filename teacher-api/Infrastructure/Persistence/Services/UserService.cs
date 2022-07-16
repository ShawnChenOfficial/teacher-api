using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using teacher_api.Domain.Entities.Users;
using teacher_api.Infrastructure.Persistence.Interfaces;
using static AspNet.Security.OpenIdConnect.Primitives.OpenIdConnectConstants;

namespace teacher_api.Infrastructure.Persistence.Services
{
	public class UserService:IUserService
	{
        private readonly IHttpContextAccessor httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public string UserId => this.httpContextAccessor.HttpContext!.User.FindFirstValue(Claims.Subject);
    }
}

