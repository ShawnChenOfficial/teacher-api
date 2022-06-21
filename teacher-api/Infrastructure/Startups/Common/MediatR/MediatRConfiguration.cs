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
            builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return builder.ConfigureServices().ConfigureInfrastructures();
        }

        /// <summary>
        /// interface/services configuration goes here
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            return builder;
        }

        /// <summary>
        /// repository configuration goes here
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static WebApplicationBuilder ConfigureInfrastructures(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return builder;
        }
    }
}

