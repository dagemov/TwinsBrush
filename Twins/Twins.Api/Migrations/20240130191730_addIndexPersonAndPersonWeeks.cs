using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class addIndexPersonAndPersonWeeks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonWeek_Person_PersonId",
                table: "PersonWeek");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonWeek_WeekWorkeds_WeekWorkedId",
                table: "PersonWeek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonWeek",
                table: "PersonWeek");

            migrationBuilder.DropIndex(
                name: "IX_PersonWeek_PersonId",
                table: "PersonWeek");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Person",
                table: "Person");

            migrationBuilder.RenameTable(
                name: "PersonWeek",
                newName: "PersonWeeks");

            migrationBuilder.RenameTable(
                name: "Person",
                newName: "Persons");

            migrationBuilder.RenameIndex(
                name: "IX_PersonWeek_WeekWorkedId",
                table: "PersonWeeks",
                newName: "IX_PersonWeeks_WeekWorkedId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonWeeks",
                table: "PersonWeeks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWeeks_PersonId_WeekWorkedId",
                table: "PersonWeeks",
                columns: new[] { "PersonId", "WeekWorkedId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_Id_Email",
                table: "Persons",
                columns: new[] { "Id", "Email" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWeeks_Persons_PersonId",
                table: "PersonWeeks",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWeeks_WeekWorkeds_WeekWorkedId",
                table: "PersonWeeks",
                column: "WeekWorkedId",
                principalTable: "WeekWorkeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonWeeks_Persons_PersonId",
                table: "PersonWeeks");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonWeeks_WeekWorkeds_WeekWorkedId",
                table: "PersonWeeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonWeeks",
                table: "PersonWeeks");

            migrationBuilder.DropIndex(
                name: "IX_PersonWeeks_PersonId_WeekWorkedId",
                table: "PersonWeeks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_Id_Email",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "PersonWeeks",
                newName: "PersonWeek");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "Person");

            migrationBuilder.RenameIndex(
                name: "IX_PersonWeeks_WeekWorkedId",
                table: "PersonWeek",
                newName: "IX_PersonWeek_WeekWorkedId");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonWeek",
                table: "PersonWeek",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Person",
                table: "Person",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PersonWeek_PersonId",
                table: "PersonWeek",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWeek_Person_PersonId",
                table: "PersonWeek",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonWeek_WeekWorkeds_WeekWorkedId",
                table: "PersonWeek",
                column: "WeekWorkedId",
                principalTable: "WeekWorkeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
