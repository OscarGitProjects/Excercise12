using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excercise12Garage2.Models
{
    public class ParkedVehicle
    {
            public int Id { get; set; }

            [DisplayName("Type of vehicle")]
            public string VehicleType { get; set; }

            [DisplayName("Registrationnumber")]
            public string RegistrationNumber { get; set; }

            [Required(ErrorMessage = "Please insert a valid color")]
            [StringLength(20)]
            [DisplayFormat(NullDisplayText = "Undefined")]
            [DisplayName("Color")]
            public string Color { get; set; }
            [DisplayName("Manufacturer")]
            public string Make { get; set; }

            [StringLength(20)]
            [DisplayFormat(NullDisplayText = "Undefined")]
            [DisplayName("Model")]
            public string Model { get; set; }
            [DisplayName("Number of wheels")]
            public int NumberOfWheels { get; set; }
            [DisplayName("Time of arrival")]
            public DateTime CheckIn { get; set; }

            [NotMapped]
            public IEnumerable<SelectListItem> VehicleTypes { get; set; }

    }    
}
