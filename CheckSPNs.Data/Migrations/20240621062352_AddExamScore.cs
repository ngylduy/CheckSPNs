using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class AddExamScore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ExamScores",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Toan = table.Column<float>(type: "real", nullable: false),
                    NguVan = table.Column<float>(type: "real", nullable: false),
                    NgoaiNgu = table.Column<float>(type: "real", nullable: false),
                    VatLi = table.Column<float>(type: "real", nullable: false),
                    HoaHoc = table.Column<float>(type: "real", nullable: false),
                    SinhHoc = table.Column<float>(type: "real", nullable: false),
                    LichSu = table.Column<float>(type: "real", nullable: false),
                    DiaLy = table.Column<float>(type: "real", nullable: false),
                    Gdcd = table.Column<float>(type: "real", nullable: false),
                    MaNgoaiNgu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamScores", x => x.StudentId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"), "5ba3fd41-9f3b-4403-9470-74b236ee6bec", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("c2261f6d-0241-4961-9de1-6afb238efa2c"), "10f34f2b-0498-41fd-89a0-2382aba1ce46", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35"), 0, "13b4824d-d005-45ed-9d51-7241de009e42", new DateTime(2024, 6, 21, 13, 23, 51, 952, DateTimeKind.Local).AddTicks(2933), new DateTime(2024, 6, 21, 13, 23, 51, 952, DateTimeKind.Local).AddTicks(2925), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEJAbC/IdsG+ufK5VX6mvGXh8cxXw9pC5jIkaBVJDGn8oWbv+ZYYJH/fUjPWBe7+Ukg==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"), new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamScores");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c2261f6d-0241-4961-9de1-6afb238efa2c"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"), new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("5d19582e-ddc6-4f31-837c-2f5517756184"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("2e04b726-fe4c-476d-9531-6cf6d7c2fa35"));

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
    }
}
