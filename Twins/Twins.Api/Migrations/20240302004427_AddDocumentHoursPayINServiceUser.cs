using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDocumentHoursPayINServiceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployedDocument",
                table: "ServiceUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "TotalHourService",
                table: "ServiceUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "TotalToPay",
                table: "ServiceUsers",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmployedDocument",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "TotalHourService",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "TotalToPay",
                table: "ServiceUsers");
        }
    }
}
