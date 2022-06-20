using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using OpenIddict.Validation.AspNetCore;
using teacher_api.Application.Account.Services;
using teacher_api.Domain.Configurations;
using teacher_api.Domain.Entities.Users;
using static OpenIddict.Abstractions.OpenIddictConstants;

namespace teacher_api.Infrastructure.configurations.Auth
{
	public static class Authconfiguration
    {
		public static WebApplicationBuilder ConfigureAuth(this WebApplicationBuilder builder)
		{
            builder.Services.AddDefaultIdentity<ApplicationUser>(opt =>
			{
				opt.SignIn.RequireConfirmedAccount = false;
				opt.Password.RequireNonAlphanumeric = false;
				opt.Password.RequireDigit = true;
				opt.Password.RequireLowercase = true;
				opt.Password.RequireUppercase = true;
				opt.User.RequireUniqueEmail = true;
			})
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultTokenProviders();


            builder.Services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer();

            builder.Services.Configure<IdentityOptions>(opt =>
			{
				opt.ClaimsIdentity.UserIdClaimType = Claims.Name;
				opt.ClaimsIdentity.UserIdClaimType = Claims.Subject;
				opt.ClaimsIdentity.RoleClaimType = Claims.Role;
			});

            builder.Services.AddOpenIddict()
				.AddCore(opt =>
				{
					opt.UseEntityFrameworkCore().UseDbContext<ApplicationDbContext>();
				})
				.AddServer(opt =>
				{
					opt.SetTokenEndpointUris("/api/account/token");

					opt.AllowPasswordFlow().AllowRefreshTokenFlow();

					if (builder.Environment.IsDevelopment())
					{
						opt.AddDevelopmentEncryptionCertificate();
						opt.AddDevelopmentSigningCertificate();
					}
					else
					{
                        var flags = X509KeyStorageFlags.MachineKeySet;

						// cert directory
                        string path = Path.Combine(Directory.GetCurrentDirectory(), "Certificates", "OpenId", "OpenIdEncryptionCert.pfx");
                        var cert = new X509Certificate2(path, builder.Configuration.GetValue<string>("OpenIdDict:Password"), flags);

                        string singingPath = Path.Combine(Directory.GetCurrentDirectory(), "Certificates", "OpenId", "OpenIdSigningCert.pfx");
                        var signingCert = new X509Certificate2(singingPath, builder.Configuration.GetValue<string>("OpenIdDict:Password"), flags);

                        opt.AddEncryptionCertificate(cert);
                        opt.AddSigningCertificate(signingCert);
                    }

					opt.UseAspNetCore().EnableLogoutEndpointPassthrough();

					opt.AcceptAnonymousClients();
				})
				.AddValidation(opt =>
                {
					opt.UseLocalServer();
					opt.UseAspNetCore();
                });

			return builder.ConfigureServices().ConfigureInfrastructures();
        }

        /// <summary>
        /// interface/services configuration goes here
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
			builder.Services.AddScoped<AuthChallengeService>();
            builder.Services.AddScoped<AuthService>();

            return builder;
        }

        /// <summary>
        /// repository configuration goes here
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        private static WebApplicationBuilder ConfigureInfrastructures(this WebApplicationBuilder builder)
        {
            return builder;
        }

    }
}

