using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class CustomersReservationsFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 27, 11, 9, 10, 742, DateTimeKind.Local).AddTicks(2767));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 27, 10, 9, 10, 742, DateTimeKind.Local).AddTicks(2774));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 27, 12, 9, 10, 742, DateTimeKind.Local).AddTicks(2778));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 27, 14, 9, 10, 742, DateTimeKind.Local).AddTicks(2781));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 27, 13, 9, 10, 742, DateTimeKind.Local).AddTicks(2785));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 29, 9, 9, 10, 742, DateTimeKind.Local).AddTicks(2673));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 28, 9, 9, 10, 742, DateTimeKind.Local).AddTicks(2747));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 30, 9, 9, 10, 742, DateTimeKind.Local).AddTicks(2753));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 2, 9, 9, 10, 742, DateTimeKind.Local).AddTicks(2757));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 1, 9, 9, 10, 742, DateTimeKind.Local).AddTicks(2762));

            var sql = """
                      create procedure CustomersReservations (@PartySize int)
                          as
                      begin
                          Select c.CustomerId, FirstName, LastName, Email, PhoneNumber
                          from Customers c left join Reservations r
                                                     on c.CustomerId = r.CustomerId
                          where r.PartySize > @PartySize;
                      end
                      """;
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 20, 27, 13, 245, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 19, 27, 13, 245, DateTimeKind.Local).AddTicks(9167));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 21, 27, 13, 245, DateTimeKind.Local).AddTicks(9170));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 23, 27, 13, 245, DateTimeKind.Local).AddTicks(9173));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 22, 27, 13, 245, DateTimeKind.Local).AddTicks(9175));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 28, 18, 27, 13, 245, DateTimeKind.Local).AddTicks(9083));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 27, 18, 27, 13, 245, DateTimeKind.Local).AddTicks(9139));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 29, 18, 27, 13, 245, DateTimeKind.Local).AddTicks(9143));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 1, 18, 27, 13, 245, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 30, 18, 27, 13, 245, DateTimeKind.Local).AddTicks(9150));
            
            var sql = """
                      drop function dbo.CustomersReservations
                      """;
            migrationBuilder.Sql(sql);
        }
    }
}
