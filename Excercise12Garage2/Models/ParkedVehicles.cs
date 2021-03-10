using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise12Garage2.Models
{
        public class ParkedVehicle
        {
            public int Id { get; set; }

            public string VehicleType { get; set; }
            public string RegistrationNumber { get; set; }

            [Required(ErrorMessage = "Please insert a valid color")]
            [StringLength(20)]
            [DisplayFormat(NullDisplayText = "Undefined")]
            public string Color { get; set; }
            public string Make { get; set; }

            [StringLength(20)]
            [DisplayFormat(NullDisplayText = "Undefined")]
            public string Model { get; set; }
            public int NumberOfWheels { get; set; }
            public DateTime CheckIn { get; set; }



        }

    
}
