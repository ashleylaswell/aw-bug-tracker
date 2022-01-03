using Microsoft.EntityFrameworkCore.Migrations;

namespace AWBugTracker.Data.Migrations
{
    public partial class AddTicketSeverity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketSeverityId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketSeverityId",
                table: "Ticket");
        }
    }
}
