using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TourManageDb.Migrations
{
    /// <inheritdoc />
    public partial class Admin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "FirstName", "Gender", "LastName", "Password", "PhoneNumber", "Role", "UserName" },
                values: new object[] { 1, new DateTime(2026, 3, 11, 20, 28, 0, 877, DateTimeKind.Local).AddTicks(6419), "admin@gmail.com", "Admin", "Male", "", "admin123", "1234567890", 1, "Admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<long>(
                name: "PhoneNumber",
                table: "Users",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
