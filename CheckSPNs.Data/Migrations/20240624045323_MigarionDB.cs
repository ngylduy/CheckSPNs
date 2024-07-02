using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class MigarionDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("646f25ac-e4bc-4579-9586-b702fc720a91"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5f922723-07aa-41b5-9789-d1c92a8a8c2e"), new Guid("ab93615d-3086-4dfa-ac80-3ac72fdba6ca") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5f922723-07aa-41b5-9789-d1c92a8a8c2e"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ab93615d-3086-4dfa-ac80-3ac72fdba6ca"));

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "UserID",
                table: "Reports");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "UserID",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5f922723-07aa-41b5-9789-d1c92a8a8c2e"), "a44f2842-17d4-4077-a504-1bfaaec2504c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("646f25ac-e4bc-4579-9586-b702fc720a91"), "99e8a1ce-70ae-4a01-babc-9e3b666213aa", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("ab93615d-3086-4dfa-ac80-3ac72fdba6ca"), 0, "64515075-8995-46ab-8dcf-dd5d8515205f", new DateTime(2024, 6, 24, 10, 40, 13, 647, DateTimeKind.Local).AddTicks(2724), new DateTime(2024, 6, 24, 10, 40, 13, 647, DateTimeKind.Local).AddTicks(2713), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEq2xXsVidBXSkbDZmgibGIpXZFYlopnTBFAgLe1rARcsA9kzv8mEriGRGl85YUYVg==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5f922723-07aa-41b5-9789-d1c92a8a8c2e"), new Guid("ab93615d-3086-4dfa-ac80-3ac72fdba6ca") });
        }
    }
}
