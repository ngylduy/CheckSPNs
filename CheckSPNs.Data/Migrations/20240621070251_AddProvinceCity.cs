using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class AddProvinceCity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c2261f6d-0241-4961-9de1-6afb238efa2c"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"), new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35"));

            migrationBuilder.CreateTable(
                name: "ProvinceCities",
                columns: table => new
                {
                    ProvinceCityCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceCityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceCities", x => x.ProvinceCityCode);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"), "82d49f31-0822-440a-9507-4bfc847824f1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b2b7ba28-3648-4fe8-9831-66e169022e09"), "77722f50-9500-4204-9f67-39f11a1abb22", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade"), 0, "4628955c-7171-40e4-a657-05d37b94ae37", new DateTime(2024, 6, 21, 14, 2, 51, 328, DateTimeKind.Local).AddTicks(9249), new DateTime(2024, 6, 21, 14, 2, 51, 328, DateTimeKind.Local).AddTicks(9241), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEIJ6tUnfj4BwELiw5Yof0kLI0KLgdRt2ttpiY243rRREl203jk4wMfgQSX9HTyAQOA==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"), new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvinceCities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2b7ba28-3648-4fe8-9831-66e169022e09"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"), new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"), "5ba3fd41-9f3b-4403-9470-74b236ee6bec", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c2261f6d-0241-4961-9de1-6afb238efa2c"), "10f34f2b-0498-41fd-89a0-2382aba1ce46", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35"), 0, "13b4824d-d005-45ed-9d51-7241de009e42", new DateTime(2024, 6, 21, 13, 23, 51, 952, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 6, 21, 13, 23, 51, 952, DateTimeKind.Local).AddTicks(2925), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEJAbC/IdsG+ufK5VX6mvGXh8cxXw9pC5jIkaBVJDGn8oWbv+ZYYJH/fUjPWBe7+Ukg==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"), new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35") });
        }
    }
}
