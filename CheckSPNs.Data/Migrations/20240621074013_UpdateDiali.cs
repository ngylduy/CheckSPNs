using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class UpdateDiali : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2b7ba28-3648-4fe8-9831-66e169022e09"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"), new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade"));

            migrationBuilder.RenameColumn(
                name: "DiaLy",
                table: "ExamScores",
                newName: "DiaLi");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "DiaLi",
                table: "ExamScores",
                newName: "DiaLy");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"), "82d49f31-0822-440a-9507-4bfc847824f1", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("b2b7ba28-3648-4fe8-9831-66e169022e09"), "77722f50-9500-4204-9f67-39f11a1abb22", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade"), 0, "4628955c-7171-40e4-a657-05d37b94ae37", new DateTime(2024, 6, 21, 14, 2, 51, 328, DateTimeKind.Local).AddTicks(9249), new DateTime(2024, 6, 21, 14, 2, 51, 328, DateTimeKind.Local).AddTicks(9241), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEIJ6tUnfj4BwELiw5Yof0kLI0KLgdRt2ttpiY243rRREl203jk4wMfgQSX9HTyAQOA==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("a514b02f-0db4-41ab-8690-b3c1d89ce78c"), new Guid("8843589b-8afe-483e-99de-3b42ec2c8ade") });
        }
    }
}
