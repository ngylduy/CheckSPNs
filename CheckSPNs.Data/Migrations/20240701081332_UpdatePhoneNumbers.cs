using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class UpdatePhoneNumbers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("8b3f7711-7ed4-466b-b812-ffeaff262041"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("75c13f91-03fd-4b94-917a-d4980010b14e"), new Guid("c104ba30-0af8-4404-85d0-41239ae34622") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("75c13f91-03fd-4b94-917a-d4980010b14e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c104ba30-0af8-4404-85d0-41239ae34622"));

            migrationBuilder.AddColumn<int>(
                name: "NegativeReportsCount",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PositiveReportsCount",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3c3f9066-3d52-4ec0-ae38-c411025a9a8a"), "9dd5fa87-1dcd-4de2-b4e5-0b617dabab82", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"), "3bb18233-7e55-421a-b8be-b6b6d228373c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387"), 0, "ada9253e-29b3-4f42-ba2e-7935fdd6e2d1", new DateTime(2024, 7, 1, 15, 13, 32, 581, DateTimeKind.Local).AddTicks(3640), new DateTime(2024, 7, 1, 15, 13, 32, 581, DateTimeKind.Local).AddTicks(3627), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEdFyW7aZe1Um6eUI4i7sPK9G9oWNwu9BMx3VlKkyG7/2P1eudX6ZvQTCV/5Xmq2rw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"), new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c3f9066-3d52-4ec0-ae38-c411025a9a8a"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"), new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387"));

            migrationBuilder.DropColumn(
                name: "NegativeReportsCount",
                table: "PhoneNumbers");

            migrationBuilder.DropColumn(
                name: "PositiveReportsCount",
                table: "PhoneNumbers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("75c13f91-03fd-4b94-917a-d4980010b14e"), "6de4ab24-4669-4b06-b6d0-0f5d7c53099a", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("8b3f7711-7ed4-466b-b812-ffeaff262041"), "9fe27c16-b5de-4eb2-8fcd-ce53d5feaf4e", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("c104ba30-0af8-4404-85d0-41239ae34622"), 0, "5d5efd77-b49d-4dfd-9b8d-361a8be80391", new DateTime(2024, 6, 27, 11, 42, 45, 392, DateTimeKind.Local).AddTicks(8719), new DateTime(2024, 6, 27, 11, 42, 45, 392, DateTimeKind.Local).AddTicks(8712), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEBTX7xEs/0CVw7tDUtlmwsxhjxgeryRowxs3OSuOiP/5KSKgsRi1e3tUpv0nrizR7w==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("75c13f91-03fd-4b94-917a-d4980010b14e"), new Guid("c104ba30-0af8-4404-85d0-41239ae34622") });
        }
    }
}
