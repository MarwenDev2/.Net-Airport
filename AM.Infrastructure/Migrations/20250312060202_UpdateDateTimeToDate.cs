using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDateTimeToDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightId",
                table: "FlightPassenger");

            migrationBuilder.DropForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPasseportNumber",
                table: "FlightPassenger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger");

            migrationBuilder.RenameTable(
                name: "FlightPassenger",
                newName: "PassengerFlights");

            migrationBuilder.RenameIndex(
                name: "IX_FlightPassenger_PassengersPasseportNumber",
                table: "PassengerFlights",
                newName: "IX_PassengerFlights_PassengersPasseportNumber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmployementDate",
                table: "Passengers",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Passengers",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufactureDate",
                table: "MyPlanes",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FlightDate",
                table: "Flights",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveArrival",
                table: "Flights",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PassengerFlights",
                table: "PassengerFlights",
                columns: new[] { "FlightsFlightId", "PassengersPasseportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerFlights_Flights_FlightsFlightId",
                table: "PassengerFlights",
                column: "FlightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PassengerFlights_Passengers_PassengersPasseportNumber",
                table: "PassengerFlights",
                column: "PassengersPasseportNumber",
                principalTable: "Passengers",
                principalColumn: "PasseportNumber",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PassengerFlights_Flights_FlightsFlightId",
                table: "PassengerFlights");

            migrationBuilder.DropForeignKey(
                name: "FK_PassengerFlights_Passengers_PassengersPasseportNumber",
                table: "PassengerFlights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PassengerFlights",
                table: "PassengerFlights");

            migrationBuilder.RenameTable(
                name: "PassengerFlights",
                newName: "FlightPassenger");

            migrationBuilder.RenameIndex(
                name: "IX_PassengerFlights_PassengersPasseportNumber",
                table: "FlightPassenger",
                newName: "IX_FlightPassenger_PassengersPasseportNumber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EmployementDate",
                table: "Passengers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "Passengers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ManufactureDate",
                table: "MyPlanes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FlightDate",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EffectiveArrival",
                table: "Flights",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightPassenger",
                table: "FlightPassenger",
                columns: new[] { "FlightsFlightId", "PassengersPasseportNumber" });

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Flights_FlightsFlightId",
                table: "FlightPassenger",
                column: "FlightsFlightId",
                principalTable: "Flights",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FlightPassenger_Passengers_PassengersPasseportNumber",
                table: "FlightPassenger",
                column: "PassengersPasseportNumber",
                principalTable: "Passengers",
                principalColumn: "PasseportNumber",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
