using System;
namespace teacher_api.Infrastructure.Startups.Common.MemoryCache
{
	public static class MemoryCacheConfiguration
	{
        public static WebApplicationBuilder ConfigureMemoryCache(this WebApplicationBuilder builder)
        {
            builder.Services.AddMemoryCache();

			return builder;
		}
	}
}

