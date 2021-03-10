using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Excercise12Garage2.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    NumberOfWheels = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Vehicle",
                columns: new[] { "Id", "CheckIn", "Color", "Make", "Model", "NumberOfWheels", "RegistrationNumber", "VehicleType" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 2, 22, 13, 36, 15, 269, DateTimeKind.Local).AddTicks(8000), "Blue", "Koenigsegg", "CCR", 4, "EKY 055", "Sports Car" },
                    { 2, new DateTime(2021, 2, 5, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4278), "silver", "Scania AB", "2017 Scania R Series", 8, "KST 810", "Trucks" },
                    { 3, new DateTime(2021, 2, 18, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4301), "Green", "Volvo", "2018 D Series", 8, "D 7900", "Bus" },
                    { 4, new DateTime(2021, 3, 5, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4305), "Black", "SAAB", "Saab 9000", 4, "H 965", "Car" },
                    { 5, new DateTime(2021, 3, 6, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4308), "Ash", "Husqvarna", "Husqvarna 2020", 2, "H 345", "Motorcycles" },
                    { 6, new DateTime(2021, 3, 3, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4310), "White", "SSPA Sweden AB", "SSPA 2019", 2, "IMO 8814275", "Ship" },
                    { 7, new DateTime(2021, 2, 27, 13, 36, 15, 271, DateTimeKind.Local).AddTicks(4312), "Yellow", "SAS", "Airbus A330", 3, "A330-300", "Airplane" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");
        }
    }
}
