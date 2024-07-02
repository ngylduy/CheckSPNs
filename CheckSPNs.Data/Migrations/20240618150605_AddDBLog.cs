using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class AddDBLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0300ed6-1413-4323-8d18-d623cf97d319"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b700a421-4b8b-418f-980b-f939a9a73947"), new Guid("b4d85d28-cda2-4918-bd46-0a3988912b9b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b700a421-4b8b-418f-980b-f939a9a73947"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4d85d28-cda2-4918-bd46-0a3988912b9b"));

            migrationBuilder.CreateTable(
                name: "DBLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoggedDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBLogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("335007b0-3697-4c18-aaf2-06c71bd8f8e2"), "d14c2ce0-08fa-42e2-9540-84ff7bc23018", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5966a1cb-6588-415e-a208-4d5290e22145"), "f77cdf9c-76a5-414e-99e6-0106cb3cbd92", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("6361c5e3-b060-44a4-b580-80b54f1d5a5f"), 0, "f4639a6b-326b-4720-b87c-178a787f119c", new DateTime(2024, 6, 18, 22, 6, 5, 571, DateTimeKind.Local).AddTicks(5179), new DateTime(2024, 6, 18, 22, 6, 5, 571, DateTimeKind.Local).AddTicks(5169), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAELXaSn+T+QAtQxuxzryNTFn+4qK4BmEfpawEVk/D254V7LydHzPuheYutSRripal5A==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5966a1cb-6588-415e-a208-4d5290e22145"), new Guid("6361c5e3-b060-44a4-b580-80b54f1d5a5f") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBLogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("335007b0-3697-4c18-aaf2-06c71bd8f8e2"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5966a1cb-6588-415e-a208-4d5290e22145"), new Guid("6361c5e3-b060-44a4-b580-80b54f1d5a5f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5966a1cb-6588-415e-a208-4d5290e22145"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6361c5e3-b060-44a4-b580-80b54f1d5a5f"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b700a421-4b8b-418f-980b-f939a9a73947"), "db9ee5f6-a0a7-4a98-a1ad-9acc450e46db", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("f0300ed6-1413-4323-8d18-d623cf97d319"), "56ab7a6e-702d-4a38-bda5-3e6c57d5ae67", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("b4d85d28-cda2-4918-bd46-0a3988912b9b"), 0, "c48fd9c2-8c45-4a51-9aad-e436c227109a", new DateTime(2024, 6, 13, 9, 45, 4, 407, DateTimeKind.Local).AddTicks(4510), new DateTime(2024, 6, 13, 9, 45, 4, 407, DateTimeKind.Local).AddTicks(4498), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEKnkr17WXp4+SnGXOTzaKmJHojJQeYNAuxFDmTttM38ZYmvxBkeZJ9ntUbmMVVCZ3w==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b700a421-4b8b-418f-980b-f939a9a73947"), new Guid("b4d85d28-cda2-4918-bd46-0a3988912b9b") });
        }
    }
}
