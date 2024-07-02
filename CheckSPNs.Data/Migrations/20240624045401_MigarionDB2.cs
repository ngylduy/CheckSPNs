using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class MigarionDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_AspNetUsers_AppUsersId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_AppUsersId",
                table: "Reports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("04b641a5-d369-40dc-a2f5-36c9732d66cf"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("e22b39d9-7918-43d0-9ea1-ad0266c41a21"), new Guid("317b770f-930a-4d26-a669-844ed7586f7b") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("e22b39d9-7918-43d0-9ea1-ad0266c41a21"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("317b770f-930a-4d26-a669-844ed7586f7b"));

            migrationBuilder.DropColumn(
                name: "AppUsersId",
                table: "Reports");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "AppUsersId",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("04b641a5-d369-40dc-a2f5-36c9732d66cf"), "f02b8120-ea9e-45fb-bfcb-3db8d805b7c8", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("e22b39d9-7918-43d0-9ea1-ad0266c41a21"), "744f5575-5c87-47a3-94f0-fcda9ff9f79f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("317b770f-930a-4d26-a669-844ed7586f7b"), 0, "6721b9ef-9b75-4e3b-9eb5-aa80675bd149", new DateTime(2024, 6, 24, 11, 53, 23, 62, DateTimeKind.Local).AddTicks(9495), new DateTime(2024, 6, 24, 11, 53, 23, 62, DateTimeKind.Local).AddTicks(9487), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAED7XD/iSl0Iqiq4ywILIS9dmCuNyyJIlgeIXnO2spwy+AlIbkJWR/vkwAmmDQUYvDA==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("e22b39d9-7918-43d0-9ea1-ad0266c41a21"), new Guid("317b770f-930a-4d26-a669-844ed7586f7b") });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_AppUsersId",
                table: "Reports",
                column: "AppUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_AspNetUsers_AppUsersId",
                table: "Reports",
                column: "AppUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
