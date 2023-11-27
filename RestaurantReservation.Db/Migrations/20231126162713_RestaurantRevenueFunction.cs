using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantReservation.Db.Migrations
{
    /// <inheritdoc />
    public partial class RestaurantRevenueFunction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                      Create Function dbo.RestaurantRevenue (@RestaurantId int)
                          returns int
                      begin
                          declare @result decimal(18,2);
                          select @result = sum(TotalAmount)
                          from Reservations r inner join Orders o on r.ReservationId = o.ReservationId
                          where RestaurantId = @RestaurantId;
                          
                          return isnull(@result, 0);
                      end
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
                      drop function dbo.RestaurantRevenue
                      go
                      """;
            migrationBuilder.Sql(sql);
        }
    }
}
