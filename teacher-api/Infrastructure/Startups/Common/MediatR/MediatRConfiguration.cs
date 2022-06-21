using System;
using System.Reflection;
using FluentValidation;
using MediatR;
using teacher_api.Application.Base.Common;

namespace teacher_api.Infrastructure.Startups.Common.MediatR
{
	public static class MediatRConfiguration
	{
		public static WebApplicationBuilder ConfigureMediatR(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return builder;
        }
	}
}

