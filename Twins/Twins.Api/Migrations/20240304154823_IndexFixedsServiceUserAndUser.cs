using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class IndexFixedsServiceUserAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_ServiceId_UserId",
                table: "ServiceUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmployedDocument",
                table: "ServiceUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_ServiceId_EmployedDocument",
                table: "ServiceUsers",
                columns: new[] { "ServiceId", "EmployedDocument" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id_Documment",
                table: "AspNetUsers",
                columns: new[] { "Id", "Documment" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_ServiceId_EmployedDocument",
                table: "ServiceUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_Id_Documment",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmployedDocument",
                table: "ServiceUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_ServiceId_UserId",
                table: "ServiceUsers",
                columns: new[] { "ServiceId", "UserId" },
                unique: true);
        }
    }
}
