using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise12Garage2.Models
{

    /// <summary>
    /// A View Model Object to avoid Editing or Creating Vehicle Directly
    /// </summary>
    public class VehicleEditViewModel
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string RegNum { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int NumOfWheels { get; set; }
        public DateTime TimeOfArrival { get; set; }
    }
}
