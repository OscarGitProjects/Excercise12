using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


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
        [MaxLength(1)]
        public string Color { get; set; }
        public string Make { get; set; }

        [StringLength(20)]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Please insert a valid number of wheels")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        [MaxLength(1)]
        [DisplayName("Nr Of Wheels")]
        public int NumberOfWheels { get; set; }

        [DisplayName("Time Checked Out")]
        public DateTime CheckIn { get; set; }

       

       
        
       
    }


}
    

