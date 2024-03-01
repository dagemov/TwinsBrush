using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixedWeekAndDayEntitiesCalendar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
