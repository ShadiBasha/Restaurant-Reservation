using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class EmployeeView : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 1,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 17, 58, 33, 398, DateTimeKind.Local).AddTicks(5442));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 2,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 16, 58, 33, 398, DateTimeKind.Local).AddTicks(5445));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 3,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 18, 58, 33, 398, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 4,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 20, 58, 33, 398, DateTimeKind.Local).AddTicks(5451));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderId",
                keyValue: 5,
                column: "OrderDate",
                value: new DateTime(2023, 11, 26, 19, 58, 33, 398, DateTimeKind.Local).AddTicks(5453));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 28, 15, 58, 33, 398, DateTimeKind.Local).AddTicks(5366));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 27, 15, 58, 33, 398, DateTimeKind.Local).AddTicks(5427));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 3,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 29, 15, 58, 33, 398, DateTimeKind.Local).AddTicks(5431));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 4,
                column: "ReservationDate",
                value: new DateTime(2023, 12, 1, 15, 58, 33, 398, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 5,
                column: "ReservationDate",
                value: new DateTime(2023, 11, 30, 15, 58, 33, 398, DateTimeKind.Local).AddTicks(5438));

            var sql = """
                      create view dbo.EmployeeView as
                      select e.FirstName, e.LastName, r.Name as "RestaurantName", e.Position
                      from Employees e left join Restaurants r on e.RestaurantId = r.RestaurantId
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

            migrationBuilder.Sql(@"drop view dbo.EmployeeView
                                    go");
        }
    }
}
