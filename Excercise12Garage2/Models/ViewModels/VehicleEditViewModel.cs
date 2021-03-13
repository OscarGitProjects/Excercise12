using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excercise12Garage2.Models
{

    /// <summary>
    /// A View Model Object to avoid Editing or Creating Vehicle Directly
    /// </summary>
    public class VehicleEditViewModel
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

        [Range(0, 1000, ErrorMessage = "Cannot select less than one")]
        public int NumberOfWheels { get; set; }
        public DateTime CheckIn { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> VehicleTypes { get; set; }

    }
}
