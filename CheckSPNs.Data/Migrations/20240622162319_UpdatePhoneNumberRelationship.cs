using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class UpdatePhoneNumberRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneNumbers_TypeOfReports_TypeOfReportsId",
                table: "PhoneNumbers");

            migrationBuilder.DropIndex(
                name: "IX_PhoneNumbers_TypeOfReportsId",
                table: "PhoneNumbers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("49188bde-2c51-4846-8963-ecc0debfd7da"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("9e6ff8c7-0e61-45aa-83b9-9e2ac397d48a"), new Guid("75128936-1f85-48c6-8484-397277064720") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("9e6ff8c7-0e61-45aa-83b9-9e2ac397d48a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("75128936-1f85-48c6-8484-397277064720"));

            migrationBuilder.DropColumn(
                name: "TypeOfReportsId",
                table: "PhoneNumbers");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "PhoneNumbersTypeOfReports",
                columns: table => new
                {
                    PhoneNumbersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeOfReportsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneNumbersTypeOfReports", x => new { x.PhoneNumbersId, x.TypeOfReportsId });
                    table.ForeignKey(
                        name: "FK_PhoneNumbersTypeOfReports_PhoneNumbers_PhoneNumbersId",
                        column: x => x.PhoneNumbersId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneNumbersTypeOfReports_TypeOfReports_TypeOfReportsId",
                        column: x => x.TypeOfReportsId,
                        principalTable: "TypeOfReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbersTypeOfReports_TypeOfReportsId",
                table: "PhoneNumbersTypeOfReports",
                column: "TypeOfReportsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneNumbersTypeOfReports");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "UserID",
                table: "Reports",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "TypeOfReportsId",
                table: "PhoneNumbers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("49188bde-2c51-4846-8963-ecc0debfd7da"), "675408cf-41b2-49b6-88dc-598e2b85fc4b", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("9e6ff8c7-0e61-45aa-83b9-9e2ac397d48a"), "e35bfa8d-3145-48c6-b45f-3d71aa3e1c64", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("75128936-1f85-48c6-8484-397277064720"), 0, "0177be8f-b7df-4b50-90be-df9593d8d6cd", new DateTime(2024, 6, 22, 23, 20, 22, 420, DateTimeKind.Local).AddTicks(9981), new DateTime(2024, 6, 22, 23, 20, 22, 420, DateTimeKind.Local).AddTicks(9971), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEPGWY3jBQTfX/auZMWxt/rHdd6f/e5BAPdrLYq4SR9tHfKPupuGTIl4WPmhE/2hheA==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("9e6ff8c7-0e61-45aa-83b9-9e2ac397d48a"), new Guid("75128936-1f85-48c6-8484-397277064720") });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneNumbers_TypeOfReportsId",
                table: "PhoneNumbers",
                column: "TypeOfReportsId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneNumbers_TypeOfReports_TypeOfReportsId",
                table: "PhoneNumbers",
                column: "TypeOfReportsId",
                principalTable: "TypeOfReports",
                principalColumn: "Id");
        }
    }
}
