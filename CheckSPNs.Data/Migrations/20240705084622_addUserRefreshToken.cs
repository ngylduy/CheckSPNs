using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CheckSPNs.Data.Migrations
{
    public partial class addUserRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3c3f9066-3d52-4ec0-ae38-c411025a9a8a"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"), new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387"));

            migrationBuilder.CreateTable(
                name: "UserRefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JwtId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    AddedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"), "917081c0-f30f-48f0-afdc-b531999f5a7b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("ff19495d-791f-436c-ac57-101d381fb82e"), "c5cfd070-9685-496b-84a3-d3d320a07b51", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0"), 0, "bc6daa07-a578-42a1-aa87-7e0f13402b2b", new DateTime(2024, 7, 5, 15, 46, 21, 757, DateTimeKind.Local).AddTicks(6465), new DateTime(2024, 7, 5, 15, 46, 21, 757, DateTimeKind.Local).AddTicks(6457), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEKx+j8GKFjpYKBWC+n0AdZEkg4T+tqGuhpeds/lrPsVyYcOE2ULp01bNSVUmKhoBcw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"), new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0") });

            migrationBuilder.CreateIndex(
                name: "IX_UserRefreshToken_UserId",
                table: "UserRefreshToken",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRefreshToken");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ff19495d-791f-436c-ac57-101d381fb82e"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"), new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ceb68fe5-459c-4bb6-b080-956278237b26"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("74cc9e5c-b242-4a05-ac7d-289c3bfe15c0"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("3c3f9066-3d52-4ec0-ae38-c411025a9a8a"), "9dd5fa87-1dcd-4de2-b4e5-0b617dabab82", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"), "3bb18233-7e55-421a-b8be-b6b6d228373c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Dob", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureUser", "SecurityStamp", "Sex", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387"), 0, "ada9253e-29b3-4f42-ba2e-7935fdd6e2d1", new DateTime(2024, 7, 1, 15, 13, 32, 581, DateTimeKind.Local).AddTicks(3640), new DateTime(2024, 7, 1, 15, 13, 32, 581, DateTimeKind.Local).AddTicks(3627), "admin@gmail.com", false, "Admin", "Website", false, null, "ADMIN@GMAIL.COM", "ADMINISTRATOR", "AQAAAAEAACcQAAAAEEdFyW7aZe1Um6eUI4i7sPK9G9oWNwu9BMx3VlKkyG7/2P1eudX6ZvQTCV/5Xmq2rw==", null, false, "default", null, "Male", false, "administrator" });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("acca46a6-2ef8-443c-b136-ab4b285732a8"), new Guid("55ae20d0-9288-459b-aa47-d367a6b0f387") });
        }
    }
}
