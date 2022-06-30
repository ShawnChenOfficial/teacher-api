using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using teacher_api.Domain.Entities.Categories;
using teacher_api.Domain.Entities.Users;

namespace teacher_api.Infrastructure.Persistence.Configurations.DataSeeder
{
    public static class DataSeeder
    {
        public static ModelBuilder SeedData(this ModelBuilder mb)
        {
            List<IdentityRole> roles = new List<IdentityRole>();

            Enum.GetNames(typeof(UserRoles)).ToList().ForEach(f =>
            {
                roles.Add(new IdentityRole { Name = f, NormalizedName = f.ToUpper() });
            });

            mb.Entity<IdentityRole>().HasData(roles);

            var passwordHasher = new PasswordHasher<ApplicationUser>();

            List<ApplicationUser> users = new List<ApplicationUser>()
            {
                 new ApplicationUser {
                    UserName = "shawnchenofficial@gmail.com",
                    NormalizedUserName = "SHAWNCHENOFFICIAL@GMAIL.COM",
                    Email = "shawnchenofficial@gmail.com",
                    NormalizedEmail = "SHAWNCHENOFFICIAL@GMAIL.COM",
                    BackgroundImagePath = "",
                    ProfileImagePath = "",
                    Title = "Mrs",
                    FirstName = "Shawn",
                    Lastname = "Chen",
                    Gender = UserGender.Male
                 }
            };

            mb.Entity<ApplicationUser>().HasData(users);

            // Add Password For All Users
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Passc0de!");

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();

            userRoles.Add(new IdentityUserRole<string>
            {
                UserId = users[0].Id,
                RoleId = roles.First(q => q.Name == "Admin").Id
            });

            mb.Entity<IdentityUserRole<string>>().HasData(userRoles);

            return mb;
        }
    }
}

