using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddDateValueServiceDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DateValue",
                table: "ServiceDays",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateValue",
                table: "ServiceDays");
        }
    }
}
