using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excercise12Garage2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Garage",
                columns: table => new
                {
                    GaregeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfParkingPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garage", x => x.GaregeId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Make = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    NumberOfWheels = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleParkingPlace",
                columns: table => new
                {
                    ParkingPlaceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsAvailableParkingPlace = table.Column<bool>(type: "bit", nullable: false),
                    IsFreeParkingPlace = table.Column<bool>(type: "bit", nullable: false),
                    IsHandicapped = table.Column<bool>(type: "bit", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: true),
                    GarageGaregeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleParkingPlace", x => x.ParkingPlaceId);
                    table.ForeignKey(
                        name: "FK_VehicleParkingPlace_Garage_GarageGaregeId",
                        column: x => x.GarageGaregeId,
                        principalTable: "Garage",
                        principalColumn: "GaregeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VehicleParkingPlace_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Garage",
                columns: new[] { "GaregeId", "Name", "NumberOfParkingPlaces" },
                values: new object[] { 1, "Group 3. Garage", 0 });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "CheckIn", "Color", "Make", "Model", "NumberOfWheels", "RegistrationNumber", "VehicleType" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 27, 9, 49, 50, 889, DateTimeKind.Local).AddTicks(9278), "Blue", "Koenigsegg", "CCR", 4, "EKY 055", "Sportscar" },
                    { 2, new DateTime(2021, 2, 10, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8050), "silver", "Scania AB", "2017 Scania R Series", 8, "KST 810", "Truck" },
                    { 3, new DateTime(2021, 2, 23, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8133), "Green", "Volvo", "2018 D Series", 8, "D 7900", "Bus" },
                    { 4, new DateTime(2021, 3, 10, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8152), "Black", "SAAB", "Saab 9000", 4, "H 965", "Boat" },
                    { 5, new DateTime(2021, 3, 11, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8167), "Ash", "Husqvarna", "Husqvarna 2020", 2, "H 345", "Motorcycle" },
                    { 6, new DateTime(2021, 3, 8, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8187), "White", "SSPA Sweden AB", "SSPA 2019", 2, "IMO 8814275", "Boat" },
                    { 7, new DateTime(2021, 3, 4, 9, 49, 50, 896, DateTimeKind.Local).AddTicks(8201), "Yellow", "SAS", "Airbus A330", 3, "A330-300", "Airplane" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleParkingPlace_GarageGaregeId",
                table: "VehicleParkingPlace",
                column: "GarageGaregeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleParkingPlace_VehicleId",
                table: "VehicleParkingPlace",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VehicleParkingPlace");

            migrationBuilder.DropTable(
                name: "Garage");

            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
