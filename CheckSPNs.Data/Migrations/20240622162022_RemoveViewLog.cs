using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class RemoveViewLog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViewLogs");

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

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "PhoneNumbers");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "PhoneNumbers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ViewLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppUsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ViewDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ViewLogs_AspNetUsers_AppUsersId",
                        column: x => x.AppUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ViewLogs_PhoneNumbers_PhoneNumberId",
                        column: x => x.PhoneNumberId,
                        principalTable: "PhoneNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_ViewLogs_AppUsersId",
                table: "ViewLogs",
                column: "AppUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_ViewLogs_PhoneNumberId",
                table: "ViewLogs",
                column: "PhoneNumberId");
        }
    }
}
