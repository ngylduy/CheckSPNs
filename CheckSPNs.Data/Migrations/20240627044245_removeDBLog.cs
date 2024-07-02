using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class removeDBLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DBLogs");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e3670717-c554-4ede-b712-e0c3e8e2fb62"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("2aa3c5f0-fb2a-492d-ac72-7144eacc33d0"), new Guid("1959502d-7475-4dc3-acbe-e0c9008d298f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2aa3c5f0-fb2a-492d-ac72-7144eacc33d0"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1959502d-7475-4dc3-acbe-e0c9008d298f"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "DBLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoggedDate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Logger = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DBLogs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("2aa3c5f0-fb2a-492d-ac72-7144eacc33d0"), "9ed3d0cf-59f5-4685-b51e-ae5c8ae854fd", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e3670717-c554-4ede-b712-e0c3e8e2fb62"), "f56ee0cd-cc6d-4bc5-9bc7-36156f8439a0", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1959502d-7475-4dc3-acbe-e0c9008d298f"), 0, "18b1537b-d658-4594-8c62-e1a5e8533bb6", new DateTime(2024, 6, 24, 11, 54, 1, 41, DateTimeKind.Local).AddTicks(7737), new DateTime(2024, 6, 24, 11, 54, 1, 41, DateTimeKind.Local).AddTicks(7727), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHP2VddA+Zig6O8rEzjNtHS+GNlG57dDrNnJxInDqj6ENhxZ5WQa92uoEfQCsycqIQ==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("2aa3c5f0-fb2a-492d-ac72-7144eacc33d0"), new Guid("1959502d-7475-4dc3-acbe-e0c9008d298f") });
        }
    }
}
