using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class updatephonenumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c653b23b-d0c5-4d65-8125-86de39ff4af0"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d82c43dc-d5de-487e-a0e2-b5e18a239997"), new Guid("1b0b061b-ba0d-4b79-8b61-a54402659042") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d82c43dc-d5de-487e-a0e2-b5e18a239997"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("1b0b061b-ba0d-4b79-8b61-a54402659042"));

            migrationBuilder.AlterColumn<long>(
                name: "TimesReported",
                table: "PhoneNumbers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "PositiveReportsCount",
                table: "PhoneNumbers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "NegativeReportsCount",
                table: "PhoneNumbers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<long>(
                name: "Views",
                table: "PhoneNumbers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("0768b192-8ca2-45f4-8a5e-37740554ec7e"), "193eb899-86f0-4bbe-ad5d-9a5de9603a8b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7c908fd5-1392-4384-9364-e40605538cc5"), "0029c5f0-dea9-4770-b34f-547b926608d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("40414fec-f075-4de2-9e85-f1e3855a9ce0"), 0, "a52577e1-e584-45e3-bb69-77fc1d30ab8c", new DateTime(2024, 7, 9, 10, 3, 24, 34, DateTimeKind.Local).AddTicks(9589), new DateTime(2024, 7, 9, 10, 3, 24, 34, DateTimeKind.Local).AddTicks(9580), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEHx+Uym7gYCc4nmfYKSaDzQbiTi1hBhG0IWmpv46ODN5RuegFxF64pitQPXjgCJmYw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("7c908fd5-1392-4384-9364-e40605538cc5"), new Guid("40414fec-f075-4de2-9e85-f1e3855a9ce0") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0768b192-8ca2-45f4-8a5e-37740554ec7e"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7c908fd5-1392-4384-9364-e40605538cc5"), new Guid("40414fec-f075-4de2-9e85-f1e3855a9ce0") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c908fd5-1392-4384-9364-e40605538cc5"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("40414fec-f075-4de2-9e85-f1e3855a9ce0"));

            migrationBuilder.DropColumn(
                name: "Views",
                table: "PhoneNumbers");

            migrationBuilder.AlterColumn<int>(
                name: "TimesReported",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "PositiveReportsCount",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<int>(
                name: "NegativeReportsCount",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c653b23b-d0c5-4d65-8125-86de39ff4af0"), "db37b69a-f235-4d3d-bc5e-c422d6de0fc5", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("d82c43dc-d5de-487e-a0e2-b5e18a239997"), "681dae12-5671-4baf-92ac-8a5e9da98fd9", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("1b0b061b-ba0d-4b79-8b61-a54402659042"), 0, "0723a4bb-85e5-4431-8cc1-7e60afe6bf41", new DateTime(2024, 7, 6, 15, 25, 19, 701, DateTimeKind.Local).AddTicks(1738), new DateTime(2024, 7, 6, 15, 25, 19, 701, DateTimeKind.Local).AddTicks(1728), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEDW1s7EOaV9TvfvU0zZwxV62+8mWP0n9wxKqJ29h9ppEQb8KJO/hMEfhfMIY1RzhyA==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("d82c43dc-d5de-487e-a0e2-b5e18a239997"), new Guid("1b0b061b-ba0d-4b79-8b61-a54402659042") });
        }
    }
}
