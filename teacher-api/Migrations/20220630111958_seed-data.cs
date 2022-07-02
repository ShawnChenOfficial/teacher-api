using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace teacher_api.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2e314efc-9ddb-41f4-b018-78ab8b7c10b9", "35bd640d-6b6e-4228-9734-bb528c3c8132", "OrganizationUser", "ORGANIZATIONUSER" },
                    { "5f58ca37-e0da-4d6d-80da-ca835b613321", "438d8ac0-c27d-41ec-bc54-7cd0bba34bb8", "OrganizationAdmin", "ORGANIZATIONADMIN" },
                    { "61f34500-e388-48c1-932a-d378be8d3733", "f3970de2-3b76-4945-be4a-566456f2668a", "User", "USER" },
                    { "d9617603-cd3c-4ab7-83bc-744951f28528", "75730882-38ce-4e1e-8648-aa151f8c8c49", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BackgroundImagePath", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "OrganizationId", "OrganizationId1", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfileImagePath", "SecurityStamp", "Title", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5a729fda-bbc6-4e52-956f-2ffa45e686c8", 0, "", "f71a188b-8387-458b-bb4f-f6eae8794b1a", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "shawnchenofficial@gmail.com", false, "Shawn", 1, "Chen", false, null, "SHAWNCHENOFFICIAL@GMAIL.COM", "SHAWNCHENOFFICIAL@GMAIL.COM", null, null, "AQAAAAEAACcQAAAAEPAA1b857rFPVqwOCB+et36O4u250ZvQ1t9mmtPfbmjQQqAccGLS+gJ1YAkHGmg3Ig==", null, false, "", "ebdd7279-1aef-4152-a8ad-2a1e1405f9bd", "Mrs", false, "shawnchenofficial@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "d9617603-cd3c-4ab7-83bc-744951f28528", "5a729fda-bbc6-4e52-956f-2ffa45e686c8" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2e314efc-9ddb-41f4-b018-78ab8b7c10b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f58ca37-e0da-4d6d-80da-ca835b613321");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "61f34500-e388-48c1-932a-d378be8d3733");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "d9617603-cd3c-4ab7-83bc-744951f28528", "5a729fda-bbc6-4e52-956f-2ffa45e686c8" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9617603-cd3c-4ab7-83bc-744951f28528");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "5a729fda-bbc6-4e52-956f-2ffa45e686c8");
        }
    }
}
