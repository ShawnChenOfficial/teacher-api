using Microsoft.EntityFrameworkCore;
using teacher_api.Domain.Configurations;

namespace teacher_api.Startups.Common.Origins
{
	public static class OriginConfiguration
	{
		public static WebApplicationBuilder ConfigureOrigins(this WebApplicationBuilder builder)
		{
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(name: "ALLOWSPECIFICORIGINS", builder =>
                {
                    builder.AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                    .WithOrigins("http://locahost:4200");
                });
            });

            return builder;
        }
    }
}

