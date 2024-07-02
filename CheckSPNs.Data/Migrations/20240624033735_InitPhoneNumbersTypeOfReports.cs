using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class InitPhoneNumbersTypeOfReports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
