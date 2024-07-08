using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class removeJwtId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff19495d-791f-436c-ac57-101d381fb82e"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"), new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0"));

            migrationBuilder.DropColumn(
                name: "JwtId",
                table: "UserRefreshToken");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5feb8ff5-392c-4304-8128-66dd6e6d92af"), "3f4aabe1-641a-4127-b015-af056f989ea3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("6cce7dff-a481-44b2-a27a-fc5bde7f997a"), "b8f7ba56-3aad-45cf-b097-6511fc182cfa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("eaf07d9a-2b3d-4f0b-8995-85b4fe00595a"), 0, "3a509f3f-6e77-4937-8d36-1f848ad86217", new DateTime(2024, 7, 5, 21, 37, 26, 898, DateTimeKind.Local).AddTicks(359), new DateTime(2024, 7, 5, 21, 37, 26, 898, DateTimeKind.Local).AddTicks(352), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEI4e52aWpRIqzhYw3H9305IJv+ghLQTX3MTW4LMHAK0KxdlXaubL4LLx9Wn7Z0jZqw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("6cce7dff-a481-44b2-a27a-fc5bde7f997a"), new Guid("eaf07d9a-2b3d-4f0b-8995-85b4fe00595a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5feb8ff5-392c-4304-8128-66dd6e6d92af"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("6cce7dff-a481-44b2-a27a-fc5bde7f997a"), new Guid("eaf07d9a-2b3d-4f0b-8995-85b4fe00595a") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6cce7dff-a481-44b2-a27a-fc5bde7f997a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eaf07d9a-2b3d-4f0b-8995-85b4fe00595a"));

            migrationBuilder.AddColumn<string>(
                name: "JwtId",
                table: "UserRefreshToken",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"), "917081c0-f30f-48f0-afdc-b531999f5a7b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ff19495d-791f-436c-ac57-101d381fb82e"), "c5cfd070-9685-496b-84a3-d3d320a07b51", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0"), 0, "bc6daa07-a578-42a1-aa87-7e0f13402b2b", new DateTime(2024, 7, 5, 15, 46, 21, 757, DateTimeKind.Local).AddTicks(6465), new DateTime(2024, 7, 5, 15, 46, 21, 757, DateTimeKind.Local).AddTicks(6457), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEKx+j8GKFjpYKBWC+n0AdZEkg4T+tqGuhpeds/lrPsVyYcOE2ULp01bNSVUmKhoBcw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"), new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0") });
        }
    }
}
