using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class removeExam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamScores");

            migrationBuilder.DropTable(
                name: "ProvinceCities");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("cff48ae9-fc81-4490-8140-00ba002575b5"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("26df9401-c7c4-455c-89b4-1c3da65c8997"), new Guid("53f74ed4-acb6-4565-b3e6-9f2c452c10be") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("26df9401-c7c4-455c-89b4-1c3da65c8997"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("53f74ed4-acb6-4565-b3e6-9f2c452c10be"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("7c44220e-0269-4edf-8c87-8f1f083c9aed"), "8881d25a-d8b5-470c-a9a4-7037168ab2c3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("87dec6a3-7932-49bc-b44c-1ad01915553a"), "d8144cd3-8bf0-4920-b0fd-fe83405cb8a4", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("e39ac820-eba5-4e39-a9f8-91beec6757a6"), 0, "ce59c068-67ba-4552-b0a8-495da0a423df", new DateTime(2024, 6, 22, 11, 28, 22, 556, DateTimeKind.Local).AddTicks(41), new DateTime(2024, 6, 22, 11, 28, 22, 556, DateTimeKind.Local).AddTicks(32), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEB2vgtEL+TrQ3mKFIODz0j5Em41R7qLCHCtOtncNvlIC3JLfLiGwkLcq6OC7e9G9cw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("87dec6a3-7932-49bc-b44c-1ad01915553a"), new Guid("e39ac820-eba5-4e39-a9f8-91beec6757a6") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7c44220e-0269-4edf-8c87-8f1f083c9aed"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("87dec6a3-7932-49bc-b44c-1ad01915553a"), new Guid("e39ac820-eba5-4e39-a9f8-91beec6757a6") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("87dec6a3-7932-49bc-b44c-1ad01915553a"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e39ac820-eba5-4e39-a9f8-91beec6757a6"));

            migrationBuilder.CreateTable(
                name: "ExamScores",
                columns: table => new
                {
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DiaLi = table.Column<float>(type: "real", nullable: false),
                    Gdcd = table.Column<float>(type: "real", nullable: false),
                    HoaHoc = table.Column<float>(type: "real", nullable: false),
                    LichSu = table.Column<float>(type: "real", nullable: false),
                    MaNgoaiNgu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgoaiNgu = table.Column<float>(type: "real", nullable: false),
                    NguVan = table.Column<float>(type: "real", nullable: false),
                    SinhHoc = table.Column<float>(type: "real", nullable: false),
                    Toan = table.Column<float>(type: "real", nullable: false),
                    VatLi = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamScores", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceCities",
                columns: table => new
                {
                    ProvinceCityCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProvinceCityName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceCities", x => x.ProvinceCityCode);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("26df9401-c7c4-455c-89b4-1c3da65c8997"), "3b19fd61-4bd2-4dea-b66b-d3ad146c863e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("cff48ae9-fc81-4490-8140-00ba002575b5"), "4f2ba58f-5227-4ad7-8604-eaee761974b4", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("53f74ed4-acb6-4565-b3e6-9f2c452c10be"), 0, "e3493450-3646-4a99-8287-8a8a08ad0b96", new DateTime(2024, 6, 21, 14, 40, 13, 381, DateTimeKind.Local).AddTicks(2863), new DateTime(2024, 6, 21, 14, 40, 13, 381, DateTimeKind.Local).AddTicks(2853), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAELXjxL63Zvc5C6Gnu/MDXYfVvefqGY3VGLTSlSne7PvxMyPqIVpjCQwuZbfLT8ovPw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("26df9401-c7c4-455c-89b4-1c3da65c8997"), new Guid("53f74ed4-acb6-4565-b3e6-9f2c452c10be") });
        }
    }
}
