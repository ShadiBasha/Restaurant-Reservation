using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class ReservationView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 17, 25, 0, 368, DateTimeKind.Local).AddTicks(4578));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 16, 25, 0, 368, DateTimeKind.Local).AddTicks(4582));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 18, 25, 0, 368, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 20, 25, 0, 368, DateTimeKind.Local).AddTicks(4589));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 19, 25, 0, 368, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 28, 15, 25, 0, 368, DateTimeKind.Local).AddTicks(4506));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 27, 15, 25, 0, 368, DateTimeKind.Local).AddTicks(4561));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 29, 15, 25, 0, 368, DateTimeKind.Local).AddTicks(4566));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 1, 15, 25, 0, 368, DateTimeKind.Local).AddTicks(4569));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 30, 15, 25, 0, 368, DateTimeKind.Local).AddTicks(4573));

            var sql = """
                      create view dbo.ReservationView as
                      select c.firstname,
                             c.lastname,
                             r.ReservationDate,
                             r.PartySize,
                             c.email,
                             c.phonenumber  as "CustomerNumber",
                             rs.Name        as "RestaurantName",
                             rs.Address,
                             rs.PhoneNumber as "RestaurantNumber"
                      from Reservations r
                               left join Customers c
                                         on r.CustomerId = c.CustomerId
                               left join Restaurants rs on r.RestaurantId = rs.RestaurantId
                      go
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
                value: new DateTime(2023, 11, 23, 19, 31, 31, 413, DateTimeKind.Local).AddTicks(5762));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 23, 18, 31, 31, 413, DateTimeKind.Local).AddTicks(5766));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 23, 20, 31, 31, 413, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 23, 22, 31, 31, 413, DateTimeKind.Local).AddTicks(5772));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 23, 21, 31, 31, 413, DateTimeKind.Local).AddTicks(5775));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 25, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5691));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 24, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 26, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5751));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 28, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5755));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 27, 17, 31, 31, 413, DateTimeKind.Local).AddTicks(5758));
            migrationBuilder.Sql(@"drop view dbo.ReservationView
                                    go");
        }
    }
}
