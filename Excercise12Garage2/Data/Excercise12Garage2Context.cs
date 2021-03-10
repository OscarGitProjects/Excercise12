using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Excercise12Garage2.Models;

namespace Excercise12Garage2.Data
{
    public class Excercise12Garage2Context : DbContext
    {
        public Excercise12Garage2Context (DbContextOptions<Excercise12Garage2Context> options)
            : base(options)
        {
        }

        public DbSet<Excercise12Garage2.Models.Vehicle> Vehicle { get; set; }
    }
}
