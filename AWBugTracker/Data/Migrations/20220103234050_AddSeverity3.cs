using Microsoft.EntityFrameworkCore.Migrations;

namespace AWBugTracker.Data.Migrations
{
    public partial class AddSeverity3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_TicketSeverityId",
                table: "Ticket",
                column: "TicketSeverityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_TicketSeverity_TicketSeverityId",
                table: "Ticket",
                column: "TicketSeverityId",
                principalTable: "TicketSeverity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_TicketSeverity_TicketSeverityId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketSeverity");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_TicketSeverityId",
                table: "Ticket");
        }
    }
}
