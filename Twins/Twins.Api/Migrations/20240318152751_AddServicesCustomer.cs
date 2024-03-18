using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Twins.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddServicesCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerDocuments",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "Register",
                table: "ServiceUsers");

            migrationBuilder.AddColumn<int>(
                name: "StreetId",
                table: "ServiceUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberAgency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerDocument = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TotalHourService = table.Column<float>(type: "real", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceCustomers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCustomers_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceUsers_StreetId",
                table: "ServiceUsers",
                column: "StreetId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCustomers_ServiceId_CustomerDocument",
                table: "ServiceCustomers",
                columns: new[] { "ServiceId", "CustomerDocument" },
                unique: true,
                filter: "[CustomerDocument] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCustomers_UserId",
                table: "ServiceCustomers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceUsers_Streets_StreetId",
                table: "ServiceUsers",
                column: "StreetId",
                principalTable: "Streets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceUsers_Streets_StreetId",
                table: "ServiceUsers");

            migrationBuilder.DropTable(
                name: "ServiceCustomers");

            migrationBuilder.DropIndex(
                name: "IX_ServiceUsers_StreetId",
                table: "ServiceUsers");

            migrationBuilder.DropColumn(
                name: "StreetId",
                table: "ServiceUsers");

            migrationBuilder.AddColumn<string>(
                name: "CustomerDocuments",
                table: "ServiceUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Register",
                table: "ServiceUsers",
                type: "bit",
                nullable: true);
        }
    }
}
