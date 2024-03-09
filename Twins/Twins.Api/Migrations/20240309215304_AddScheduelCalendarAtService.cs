using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddScheduelCalendarAtService : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Days_WeekWorkeds_WeekWorkedId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_Days_Id_WeekWorkedId",
                table: "Days");

            migrationBuilder.AddColumn<int>(
                name: "DayId",
                table: "Services",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "WeekWorkedId",
                table: "Days",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedRecord",
                table: "Days",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateName",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DateValue",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditRecord",
                table: "Days",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndBreak",
                table: "Days",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Message",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Days",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "PayByHour",
                table: "Days",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartBreak",
                table: "Days",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceDaysId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    DayId = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDays_Days_DayId",
                        column: x => x.DayId,
                        principalTable: "Days",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceDays_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_DayId",
                table: "Services",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Days_Id_WeekWorkedId",
                table: "Days",
                columns: new[] { "Id", "WeekWorkedId" },
                unique: true,
                filter: "[WeekWorkedId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ServiceDaysId",
                table: "AspNetUsers",
                column: "ServiceDaysId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDays_DayId",
                table: "ServiceDays",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDays_ServiceId_DayId",
                table: "ServiceDays",
                columns: new[] { "ServiceId", "DayId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_ServiceDays_ServiceDaysId",
                table: "AspNetUsers",
                column: "ServiceDaysId",
                principalTable: "ServiceDays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Days_WeekWorkeds_WeekWorkedId",
                table: "Days",
                column: "WeekWorkedId",
                principalTable: "WeekWorkeds",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Days_DayId",
                table: "Services",
                column: "DayId",
                principalTable: "Days",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_ServiceDays_ServiceDaysId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Days_WeekWorkeds_WeekWorkedId",
                table: "Days");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Days_DayId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "ServiceDays");

            migrationBuilder.DropIndex(
                name: "IX_Services_DayId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Days_Id_WeekWorkedId",
                table: "Days");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ServiceDaysId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DayId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CreatedRecord",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DateName",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "DateValue",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "EditRecord",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "EndBreak",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Message",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "PayByHour",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "StartBreak",
                table: "Days");

            migrationBuilder.DropColumn(
                name: "ServiceDaysId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "WeekWorkedId",
                table: "Days",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
