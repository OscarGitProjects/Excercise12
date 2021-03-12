﻿// <auto-generated />
using System;
using Excercise12Garage2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Excercise12Garage2.Migrations
{
    [DbContext(typeof(Excercise12Garage2Context))]
    partial class Excercise12Garage2ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Excercise12Garage2.Models.ParkedVehicle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Make")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int>("NumberOfWheels")
                        .HasColumnType("int");

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VehicleType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vehicle");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CheckIn = new DateTime(2021, 2, 23, 20, 32, 54, 239, DateTimeKind.Local).AddTicks(1562),
                            Color = "Blue",
                            Make = "Koenigsegg",
                            Model = "CCR",
                            NumberOfWheels = 4,
                            RegistrationNumber = "EKY 055",
                            VehicleType = "Sportscar"
                        },
                        new
                        {
                            Id = 2,
                            CheckIn = new DateTime(2021, 2, 6, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1899),
                            Color = "silver",
                            Make = "Scania AB",
                            Model = "2017 Scania R Series",
                            NumberOfWheels = 8,
                            RegistrationNumber = "KST 810",
                            VehicleType = "Truck"
                        },
                        new
                        {
                            Id = 3,
                            CheckIn = new DateTime(2021, 2, 19, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1930),
                            Color = "Green",
                            Make = "Volvo",
                            Model = "2018 D Series",
                            NumberOfWheels = 8,
                            RegistrationNumber = "D 7900",
                            VehicleType = "Bus"
                        },
                        new
                        {
                            Id = 4,
                            CheckIn = new DateTime(2021, 3, 6, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1935),
                            Color = "Black",
                            Make = "SAAB",
                            Model = "Saab 9000",
                            NumberOfWheels = 4,
                            RegistrationNumber = "H 965",
                            VehicleType = "Boat"
                        },
                        new
                        {
                            Id = 5,
                            CheckIn = new DateTime(2021, 3, 7, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1939),
                            Color = "Ash",
                            Make = "Husqvarna",
                            Model = "Husqvarna 2020",
                            NumberOfWheels = 2,
                            RegistrationNumber = "H 345",
                            VehicleType = "Motorcycle"
                        },
                        new
                        {
                            Id = 6,
                            CheckIn = new DateTime(2021, 3, 4, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1941),
                            Color = "White",
                            Make = "SSPA Sweden AB",
                            Model = "SSPA 2019",
                            NumberOfWheels = 2,
                            RegistrationNumber = "IMO 8814275",
                            VehicleType = "Boat"
                        },
                        new
                        {
                            Id = 7,
                            CheckIn = new DateTime(2021, 2, 28, 20, 32, 54, 241, DateTimeKind.Local).AddTicks(1944),
                            Color = "Yellow",
                            Make = "SAS",
                            Model = "Airbus A330",
                            NumberOfWheels = 3,
                            RegistrationNumber = "A330-300",
                            VehicleType = "Airplane"
                        });
                });

            modelBuilder.Entity("Excercise12Garage2.Models.ViewModels.VehicleViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RegistrationNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeOfArrival")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("VehicleViewModel");
                });
#pragma warning restore 612, 618
        }
    }
}
