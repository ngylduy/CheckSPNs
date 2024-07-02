using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class ReInitPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae8984e1-6eed-4483-b21c-26f46be90d88"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("3319ed38-65f0-449a-88d8-9e8f481fa7d8"), new Guid("7a1c446c-1d5a-4101-9ad0-0b0885b62772") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3319ed38-65f0-449a-88d8-9e8f481fa7d8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7a1c446c-1d5a-4101-9ad0-0b0885b62772"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("97c75c0c-2cf8-47b1-afea-72b967d81851"), "295ae8fb-fc22-4ee0-bf7b-6796ae1f3268", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("bce6556d-cc03-4b1e-b467-65a39b8517f3"), "1f9fa6db-2c1a-40b4-922f-1df0d1eb57c1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("eb4ea65f-d960-4f46-bb77-dfef6940b24f"), 0, "71271cf8-308a-467d-849b-70dabc4dffda", new DateTime(2024, 6, 24, 10, 12, 11, 807, DateTimeKind.Local).AddTicks(9529), new DateTime(2024, 6, 24, 10, 12, 11, 807, DateTimeKind.Local).AddTicks(9522), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEGyv0uB3TRR+TJtaxoCd/Pv4pL6dGZFj/vR3kJGP8KnLdE9hb3DkjPof0R8Zj5x1ZQ==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("97c75c0c-2cf8-47b1-afea-72b967d81851"), new Guid("eb4ea65f-d960-4f46-bb77-dfef6940b24f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("bce6556d-cc03-4b1e-b467-65a39b8517f3"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("97c75c0c-2cf8-47b1-afea-72b967d81851"), new Guid("eb4ea65f-d960-4f46-bb77-dfef6940b24f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("97c75c0c-2cf8-47b1-afea-72b967d81851"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eb4ea65f-d960-4f46-bb77-dfef6940b24f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3319ed38-65f0-449a-88d8-9e8f481fa7d8"), "abbe7c20-9942-4003-823e-94682615207c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ae8984e1-6eed-4483-b21c-26f46be90d88"), "b9c6ac4c-5201-40e1-9ab6-44017b736fdf", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("7a1c446c-1d5a-4101-9ad0-0b0885b62772"), 0, "2a5af903-42c0-47b6-8f69-e7def245f877", new DateTime(2024, 6, 22, 23, 23, 19, 258, DateTimeKind.Local).AddTicks(6504), new DateTime(2024, 6, 22, 23, 23, 19, 258, DateTimeKind.Local).AddTicks(6495), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEJA5o+CDM4N+ssPgcxVARTHMM72ytMIky/SOI1+7+8WrP7fjnHO+Jy4vTJfDHQ9VjA==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("3319ed38-65f0-449a-88d8-9e8f481fa7d8"), new Guid("7a1c446c-1d5a-4101-9ad0-0b0885b62772") });
        }
    }
}
