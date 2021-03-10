using Excercise12Garage2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise12Garage2.Data
{
    public class Garage2Context : DbContext
    {
        public DbSet<ParkedVehicle> ParkedVehicle { get; set; }
        public Garage2Context(DbContextOptions<Garage2Context> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ParkedVehicle>().HasData(
                 new ParkedVehicle
                 {
                     Id = 1,
                     VehicleType = "Sports Car",
                     RegistrationNumber = "EKY 055",
                     Color = "Blue",
                     Make = "Koenigsegg",
                     Model = "CCR",
                     NumberOfWheels = 4,
                     CheckIn = DateTime.Now.AddDays(-16)
                 },
                 new ParkedVehicle
                 {
                     Id = 2,
                     VehicleType = "Trucks",
                     RegistrationNumber = "KST 810",
                     Color = "silver",
                     Make = "Scania AB",
                     Model = "2017 Scania R Series",
                     NumberOfWheels = 8,
                     CheckIn = DateTime.Now.AddDays(-33)
                 },

                 new ParkedVehicle
                 {
                     Id = 3,
                     VehicleType = "Bus",
                     RegistrationNumber = "D 7900",
                     Color = "Green",
                     Make = "Volvo",
                     Model = "2018 D Series",
                     NumberOfWheels = 8,
                     CheckIn = DateTime.Now.AddDays(-20)
                 },

                 new ParkedVehicle
                 {
                     Id = 4,
                     VehicleType = "Car",
                     RegistrationNumber = "H 965",
                     Color = "Black",
                     Make = "SAAB",
                     Model = "Saab 9000",
                     NumberOfWheels = 4,
                     CheckIn = DateTime.Now.AddDays(-5)
                 },

                 new ParkedVehicle
                 {
                     Id = 5,
                     VehicleType = "Motorcycles",
                     RegistrationNumber = "H 345",
                     Color = "Ash",
                     Make = "Husqvarna",
                     Model = "Husqvarna 2020",
                     NumberOfWheels = 2,
                     CheckIn = DateTime.Now.AddDays(-4)
                 },
                 new ParkedVehicle
                 {
                     Id = 6,
                     VehicleType = "Ship",
                     RegistrationNumber = "IMO 8814275",
                     Color = "White",
                     Make = "SSPA Sweden AB",
                     Model = "SSPA 2019",
                     NumberOfWheels = 2,
                     CheckIn = DateTime.Now.AddDays(-7)
                 },
                 new ParkedVehicle
                 {
                     Id = 7,
                     VehicleType = "Airplane",
                     RegistrationNumber = "A330-300",
                     Color = "Yellow",
                     Make = "SAS",
                     Model = "Airbus A330",
                     NumberOfWheels = 3,
                     CheckIn = DateTime.Now.AddDays(-11)
                 }


                );
        }


    }
}
