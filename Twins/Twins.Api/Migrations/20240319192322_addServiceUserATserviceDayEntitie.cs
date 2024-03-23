using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class addServiceUserATserviceDayEntitie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ServiceDays_ServiceDaysId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ServiceDaysId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ServiceDaysId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "ServiceDaysId",
                table: "ServiceUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_ServiceDaysId",
                table: "ServiceUsers",
                column: "ServiceDaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsers_ServiceDays_ServiceDaysId",
                table: "ServiceUsers",
                column: "ServiceDaysId",
                principalTable: "ServiceDays",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsers_ServiceDays_ServiceDaysId",
                table: "ServiceUsers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_ServiceDaysId",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "ServiceDaysId",
                table: "ServiceUsers");

            migrationBuilder.AddColumn<int>(
                name: "ServiceDaysId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ServiceDaysId",
                table: "AspNetUsers",
                column: "ServiceDaysId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ServiceDays_ServiceDaysId",
                table: "AspNetUsers",
                column: "ServiceDaysId",
                principalTable: "ServiceDays",
                principalColumn: "Id");
        }
    }
}
