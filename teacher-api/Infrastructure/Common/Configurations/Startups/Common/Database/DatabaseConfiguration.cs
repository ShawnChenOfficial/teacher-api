using Microsoft.EntityFrameworkCore;
using teacher_api.Domain.Configurations;

namespace teacher_api.Infrastructure.configurations.Auth
{
	public static class DatabaseConfiguration
	{
		public static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
		{
            builder.Services.AddDbContext<ApplicationDbContext>(opt =>
            {
                var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                opt.UseOpenIddict();
            });


            return builder;
        }
    }
}

