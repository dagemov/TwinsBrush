using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StreetId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_StreetId",
                table: "Services",
                column: "StreetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Streets_StreetId",
                table: "Services",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Streets_StreetId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Services_StreetId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "Services");
        }
    }
}
