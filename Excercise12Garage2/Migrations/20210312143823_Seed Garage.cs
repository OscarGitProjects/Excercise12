using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excercise12Garage2.Migrations
{
    public partial class SeedGarage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Garage",
                columns: new[] { "GaregeId", "Name", "NumberOfParkingPlaces" },
                values: new object[] { 1, "Group 3. Garage", 0 });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckIn",
                value: new DateTime(2021, 2, 24, 15, 38, 22, 353, DateTimeKind.Local).AddTicks(332));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "CheckIn",
                value: new DateTime(2021, 2, 7, 15, 38, 22, 358, DateTimeKind.Local).AddTicks(7429));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 20, 15, 38, 22, 358, DateTimeKind.Local).AddTicks(7522));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "CheckIn",
                value: new DateTime(2021, 3, 7, 15, 38, 22, 358, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "CheckIn",
                value: new DateTime(2021, 3, 8, 15, 38, 22, 358, DateTimeKind.Local).AddTicks(7669));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "CheckIn",
                value: new DateTime(2021, 3, 5, 15, 38, 22, 358, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 3, 1, 15, 38, 22, 358, DateTimeKind.Local).AddTicks(7698));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Garage",
                keyColumn: "GaregeId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckIn",
                value: new DateTime(2021, 2, 24, 15, 22, 38, 947, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "CheckIn",
                value: new DateTime(2021, 2, 7, 15, 22, 38, 951, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 20, 15, 22, 38, 951, DateTimeKind.Local).AddTicks(9044));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "CheckIn",
                value: new DateTime(2021, 3, 7, 15, 22, 38, 951, DateTimeKind.Local).AddTicks(9064));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "CheckIn",
                value: new DateTime(2021, 3, 8, 15, 22, 38, 951, DateTimeKind.Local).AddTicks(9078));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "CheckIn",
                value: new DateTime(2021, 3, 5, 15, 22, 38, 951, DateTimeKind.Local).AddTicks(9093));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 3, 1, 15, 22, 38, 951, DateTimeKind.Local).AddTicks(9108));
        }
    }
}
