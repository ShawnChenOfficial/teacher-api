using Microsoft.EntityFrameworkCore;
using teacher_api.Application.Base.Interface;
using teacher_api.Domain.Configurations;
using teacher_api.Infrastructure.Persistence.Repository;

namespace teacher_api.Infrastructure.Startups.Common.Database
{
	public static class DependenciesConfiguration
	{
		public static WebApplicationBuilder ConfigureDependencies(this WebApplicationBuilder builder)
		{
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            return builder;
        }
    }
}

