using System;
using System.Security.Claims;
using Microsoft.AspNetCore;
using Microsoft.Extensions.Caching.Memory;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace teacher_api.Infrastructure.Middlewares.Auth
{
	public class AuthBlackListMiddleware
	{
        private readonly RequestDelegate next;

        public AuthBlackListMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task InvokeAsync(HttpContext context, IMemoryCache _cache)
        {
            var xxx = context.User.Identities;

            var identity = context.User.FindFirst(Claims.Subject);

            return next(context);
        }
	}
}