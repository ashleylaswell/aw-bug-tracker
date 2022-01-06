using Microsoft.EntityFrameworkCore.Migrations;

namespace AWBugTracker.Data.Migrations
{
    public partial class AddEnum : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TicketSeverityId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ProgressId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TicketTypeEnum",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "TicketTypeEnum",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "TicketTypeId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TicketSeverityId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProgressId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Progress_ProgressId",
                table: "Ticket",
                column: "ProgressId",
                principalTable: "Progress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketSeverity_TicketSeverityId",
                table: "Ticket",
                column: "TicketSeverityId",
                principalTable: "TicketSeverity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketType_TicketTypeId",
                table: "Ticket",
                column: "TicketTypeId",
                principalTable: "TicketType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
