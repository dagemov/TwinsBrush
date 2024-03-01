using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class fixedServiceUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsers_AspNetUsers_UserId1",
                table: "ServiceUsers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_UserId1",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ServiceUsers");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ServiceUsers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_UserId",
                table: "ServiceUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsers_AspNetUsers_UserId",
                table: "ServiceUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsers_AspNetUsers_UserId",
                table: "ServiceUsers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_UserId",
                table: "ServiceUsers");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "ServiceUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ServiceUsers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_UserId1",
                table: "ServiceUsers",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsers_AspNetUsers_UserId1",
                table: "ServiceUsers",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
