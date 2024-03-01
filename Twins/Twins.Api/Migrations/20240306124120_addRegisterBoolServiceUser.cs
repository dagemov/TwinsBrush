using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class addRegisterBoolServiceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_ServiceId_EmployedDocument",
                table: "ServiceUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmployedDocument",
                table: "ServiceUsers",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<bool>(
                name: "Register",
                table: "ServiceUsers",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_ServiceId_EmployedDocument",
                table: "ServiceUsers",
                columns: new[] { "ServiceId", "EmployedDocument" },
                unique: true,
                filter: "[EmployedDocument] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_ServiceId_EmployedDocument",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "Register",
                table: "ServiceUsers");

            migrationBuilder.AlterColumn<string>(
                name: "EmployedDocument",
                table: "ServiceUsers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_ServiceId_EmployedDocument",
                table: "ServiceUsers",
                columns: new[] { "ServiceId", "EmployedDocument" },
                unique: true);
        }
    }
}
