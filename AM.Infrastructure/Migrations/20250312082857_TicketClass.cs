using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class TicketClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PassengerFlights");

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    PasseportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Seat = table.Column<int>(type: "int", nullable: false),
                    VIP = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => new { x.PasseportNumber, x.FlightId });
                    table.ForeignKey(
                        name: "FK_Ticket_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Passengers_PasseportNumber",
                        column: x => x.PasseportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PasseportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_FlightId",
                table: "Ticket",
                column: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.CreateTable(
                name: "PassengerFlights",
                columns: table => new
                {
                    FlightsFlightId = table.Column<int>(type: "int", nullable: false),
                    PassengersPasseportNumber = table.Column<string>(type: "nvarchar(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassengerFlights", x => new { x.FlightsFlightId, x.PassengersPasseportNumber });
                    table.ForeignKey(
                        name: "FK_PassengerFlights_Flights_FlightsFlightId",
                        column: x => x.FlightsFlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PassengerFlights_Passengers_PassengersPasseportNumber",
                        column: x => x.PassengersPasseportNumber,
                        principalTable: "Passengers",
                        principalColumn: "PasseportNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PassengerFlights_PassengersPasseportNumber",
                table: "PassengerFlights",
                column: "PassengersPasseportNumber");
        }
    }
}
