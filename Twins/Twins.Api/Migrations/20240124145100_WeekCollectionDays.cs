using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class WeekCollectionDays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Day_WeekWorkeds_WeekWorkedId",
                table: "Day");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Day",
                table: "Day");

            migrationBuilder.RenameTable(
                name: "Day",
                newName: "Days");

            migrationBuilder.RenameIndex(
                name: "IX_Day_WeekWorkedId",
                table: "Days",
                newName: "IX_Days_WeekWorkedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Days",
                table: "Days",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Days_Id_WeekWorkedId",
                table: "Days",
                columns: new[] { "Id", "WeekWorkedId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Days_WeekWorkeds_WeekWorkedId",
                table: "Days",
                column: "WeekWorkedId",
                principalTable: "WeekWorkeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_WeekWorkeds_WeekWorkedId",
                table: "Days");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Days",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_Id_WeekWorkedId",
                table: "Days");

            migrationBuilder.RenameTable(
                name: "Days",
                newName: "Day");

            migrationBuilder.RenameIndex(
                name: "IX_Days_WeekWorkedId",
                table: "Day",
                newName: "IX_Day_WeekWorkedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Day",
                table: "Day",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Day_WeekWorkeds_WeekWorkedId",
                table: "Day",
                column: "WeekWorkedId",
                principalTable: "WeekWorkeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
