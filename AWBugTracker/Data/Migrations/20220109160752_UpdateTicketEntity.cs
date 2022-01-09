using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AWBugTracker.Data.Migrations
{
    public partial class UpdateTicketEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Progress_ProgressId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketSeverity_TicketSeverityId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "Progress");

            migrationBuilder.DropTable(
                name: "TicketSeverity");

            migrationBuilder.DropTable(
                name: "TicketType");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_ProgressId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TicketSeverityId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TicketTypeId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketSeverityId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketTypeId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "TicketTypeEnum",
                table: "Ticket",
                newName: "TicketType");

            migrationBuilder.RenameColumn(
                name: "DateTimeTicketCreated",
                table: "Ticket",
                newName: "ModifiedOn");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketSeverity",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketSeverity",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "TicketType",
                table: "Ticket",
                newName: "TicketTypeEnum");

            migrationBuilder.RenameColumn(
                name: "ModifiedOn",
                table: "Ticket",
                newName: "DateTimeTicketCreated");

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketSeverityId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketTypeId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Progress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketSeverity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSeverity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TicketType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_ProgressId",
                table: "Ticket",
                column: "ProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketSeverityId",
                table: "Ticket",
                column: "TicketSeverityId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketTypeId",
                table: "Ticket",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Progress_ProgressId",
                table: "Ticket",
                column: "ProgressId",
                principalTable: "Progress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketSeverity_TicketSeverityId",
                table: "Ticket",
                column: "TicketSeverityId",
                principalTable: "TicketSeverity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeId",
                table: "Ticket",
                column: "TicketTypeId",
                principalTable: "TicketType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
