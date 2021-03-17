using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Excercise12Garage2.Models.ViewModels
{
    public class VehicleCountByTypeViewModel
    {
        [DisplayName("Type of vehicle")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string VehicleTyp { get; set; }

        [DisplayName("Number of vehicles")]
        public int VehicleCount { get; set; }
    }
}