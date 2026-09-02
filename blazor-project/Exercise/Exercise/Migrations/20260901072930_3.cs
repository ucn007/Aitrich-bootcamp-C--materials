using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercise.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_TourPackages_DestinationId",
                table: "TourPackages",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_TourPackages_Destinations_DestinationId",
                table: "TourPackages",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TourPackages_Destinations_DestinationId",
                table: "TourPackages");

            migrationBuilder.DropIndex(
                name: "IX_TourPackages_DestinationId",
                table: "TourPackages");
        }
    }
}
