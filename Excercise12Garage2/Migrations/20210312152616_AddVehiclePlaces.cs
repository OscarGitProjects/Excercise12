using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excercise12Garage2.Migrations
{
    public partial class AddVehiclePlaces : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GarageGaregeId",
                table: "VehicleParkingPlace",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                column: "CheckIn",
                value: new DateTime(2021, 2, 24, 16, 26, 15, 983, DateTimeKind.Local).AddTicks(9772));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                column: "CheckIn",
                value: new DateTime(2021, 2, 7, 16, 26, 15, 993, DateTimeKind.Local).AddTicks(2089));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 20, 16, 26, 15, 993, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                column: "CheckIn",
                value: new DateTime(2021, 3, 7, 16, 26, 15, 993, DateTimeKind.Local).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                column: "CheckIn",
                value: new DateTime(2021, 3, 8, 16, 26, 15, 993, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                column: "CheckIn",
                value: new DateTime(2021, 3, 5, 16, 26, 15, 993, DateTimeKind.Local).AddTicks(2260));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 3, 1, 16, 26, 15, 993, DateTimeKind.Local).AddTicks(2279));

            migrationBuilder.CreateIndex(
                name: "IX_VehicleParkingPlace_GarageGaregeId",
                table: "VehicleParkingPlace",
                column: "GarageGaregeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleParkingPlace_Garage_GarageGaregeId",
                table: "VehicleParkingPlace",
                column: "GarageGaregeId",
                principalTable: "Garage",
                principalColumn: "GaregeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleParkingPlace_Garage_GarageGaregeId",
                table: "VehicleParkingPlace");

            migrationBuilder.DropIndex(
                name: "IX_VehicleParkingPlace_GarageGaregeId",
                table: "VehicleParkingPlace");

            migrationBuilder.DropColumn(
                name: "GarageGaregeId",
                table: "VehicleParkingPlace");

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
    }
}
