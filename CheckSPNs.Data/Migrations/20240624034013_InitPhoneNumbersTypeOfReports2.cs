using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class InitPhoneNumbersTypeOfReports2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypeOfReports_PhoneNumbers_PhoneNumbersId",
                table: "TypeOfReports");

            migrationBuilder.DropIndex(
                name: "IX_TypeOfReports_PhoneNumbersId",
                table: "TypeOfReports");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("19aab234-4573-45c3-9e53-e8243e6dab0b"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9f9a12da-c4d2-4bc6-8651-9ca349ee55e8"), new Guid("59f11792-d5cb-47da-8181-6e9ec6114d21") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9f9a12da-c4d2-4bc6-8651-9ca349ee55e8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("59f11792-d5cb-47da-8181-6e9ec6114d21"));

            migrationBuilder.DropColumn(
                name: "PhoneNumbersId",
                table: "TypeOfReports");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "PhoneNumbersId",
                table: "TypeOfReports",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("19aab234-4573-45c3-9e53-e8243e6dab0b"), "26578983-6f64-440a-867c-81aaa4404e30", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9f9a12da-c4d2-4bc6-8651-9ca349ee55e8"), "d6faa1c4-5e40-40c7-889f-f0bc90d1cf82", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("59f11792-d5cb-47da-8181-6e9ec6114d21"), 0, "69f412fe-562a-43aa-be11-11f4a98861a9", new DateTime(2024, 6, 24, 10, 37, 35, 472, DateTimeKind.Local).AddTicks(9622), new DateTime(2024, 6, 24, 10, 37, 35, 472, DateTimeKind.Local).AddTicks(9615), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAECf2QzFMWoipdz+XDaM7a41N7ysfplLW+BoC9LhhrfLMGm2QgUlGsIwp+g7e+FGzkQ==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9f9a12da-c4d2-4bc6-8651-9ca349ee55e8"), new Guid("59f11792-d5cb-47da-8181-6e9ec6114d21") });

            migrationBuilder.CreateIndex(
                name: "IX_TypeOfReports_PhoneNumbersId",
                table: "TypeOfReports",
                column: "PhoneNumbersId");

            migrationBuilder.AddForeignKey(
                name: "FK_TypeOfReports_PhoneNumbers_PhoneNumbersId",
                table: "TypeOfReports",
                column: "PhoneNumbersId",
                principalTable: "PhoneNumbers",
                principalColumn: "Id");
        }
    }
}
