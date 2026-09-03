using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Destination.Migrations
{
    /// <inheritdoc />
    public partial class ddadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Registers_RegisterId",
                table: "Destinations");

            migrationBuilder.DropIndex(
                name: "IX_Destinations_RegisterId",
                table: "Destinations");

            migrationBuilder.DropColumn(
                name: "RegisterId",
                table: "Destinations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RegisterId",
                table: "Destinations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Destinations_RegisterId",
                table: "Destinations",
                column: "RegisterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Registers_RegisterId",
                table: "Destinations",
                column: "RegisterId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
