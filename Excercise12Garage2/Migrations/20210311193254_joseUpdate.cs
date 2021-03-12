using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excercise12Garage2.Migrations
{
    public partial class joseUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VehicleViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfArrival = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleViewModel", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 2, 23, 20, 32, 54, 239, DateTimeKind.Local).AddTicks(1562), "Sportscar" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 2, 6, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1899), "Truck" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 19, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1930));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 3, 6, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1935), "Boat" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 3, 7, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1939), "Motorcycle" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 3, 4, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1941), "Boat" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 2, 28, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1944));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleViewModel");

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 2, 22, 13, 36, 15, 269, DateTimeKind.Local).AddTicks(8000), "Sports Car" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 2, 5, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4278), "Trucks" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 3,
                column: "CheckIn",
                value: new DateTime(2021, 2, 18, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4301));

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 3, 5, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4305), "Car" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 3, 6, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4308), "Motorcycles" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CheckIn", "VehicleType" },
                values: new object[] { new DateTime(2021, 3, 3, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4310), "Ship" });

            migrationBuilder.UpdateData(
                table: "Vehicle",
                keyColumn: "Id",
                keyValue: 7,
                column: "CheckIn",
                value: new DateTime(2021, 2, 27, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4312));
        }
    }
}
