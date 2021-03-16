using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excercise12Garage2.Migrations
{
    public partial class GarageNumberOfParkingPlaces10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Garage",
                keyColumn: "GaregeId",
                keyValue: 1,
                column: "NumberOfParkingPlaces",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckIn",
                value: new DateTime(2021, 2, 27, 21, 3, 17, 770, DateTimeKind.Local).AddTicks(3703));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "CheckIn",
                value: new DateTime(2021, 2, 10, 21, 3, 17, 774, DateTimeKind.Local).AddTicks(3235));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 23, 21, 3, 17, 774, DateTimeKind.Local).AddTicks(3299));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "CheckIn",
                value: new DateTime(2021, 3, 10, 21, 3, 17, 774, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "CheckIn",
                value: new DateTime(2021, 3, 11, 21, 3, 17, 774, DateTimeKind.Local).AddTicks(3338));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "CheckIn",
                value: new DateTime(2021, 3, 8, 21, 3, 17, 774, DateTimeKind.Local).AddTicks(3352));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 3, 4, 21, 3, 17, 774, DateTimeKind.Local).AddTicks(3367));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Garage",
                keyColumn: "GaregeId",
                keyValue: 1,
                column: "NumberOfParkingPlaces",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckIn",
                value: new DateTime(2021, 2, 27, 9, 49, 50, 889, DateTimeKind.Local).AddTicks(9278));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "CheckIn",
                value: new DateTime(2021, 2, 10, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8050));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 23, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8133));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "CheckIn",
                value: new DateTime(2021, 3, 10, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8152));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "CheckIn",
                value: new DateTime(2021, 3, 11, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8167));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "CheckIn",
                value: new DateTime(2021, 3, 8, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8187));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 3, 4, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8201));
        }
    }
}
