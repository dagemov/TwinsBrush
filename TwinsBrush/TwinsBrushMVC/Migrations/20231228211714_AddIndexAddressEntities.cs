using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TwinsBrushMVC.Migrations
{
    public partial class AddIndexAddressEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Streets_Id_CityId",
                table: "Streets",
                columns: new[] { "Id", "CityId" });

            migrationBuilder.CreateIndex(
                name: "IX_States_Id_CountryId",
                table: "States",
                columns: new[] { "Id", "CountryId" });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Id",
                table: "Countries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Id_StateId",
                table: "Cities",
                columns: new[] { "Id", "StateId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Streets_Id_CityId",
                table: "Streets");

            migrationBuilder.DropIndex(
                name: "IX_States_Id_CountryId",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_Countries_Id",
                table: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_Cities_Id_StateId",
                table: "Cities");
        }
    }
}
