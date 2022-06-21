using System;
using MediatR;
using teacher_api.Application.Base.Common;

namespace teacher_api.Infrastructure.Common.Configurations.Startups.DependencyInjections
{
	public static class CommonConfiguration
	{
        public static WebApplicationBuilder AddDependencies(this WebApplicationBuilder builder)
        {

            return builder;
        }
    }
}

