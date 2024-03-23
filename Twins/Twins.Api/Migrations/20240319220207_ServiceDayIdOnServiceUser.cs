using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class ServiceDayIdOnServiceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ServiceDayId",
                table: "ServiceUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceDayId",
                table: "ServiceUsers");
        }
    }
}
