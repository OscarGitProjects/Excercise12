using System.ComponentModel;

namespace Excercise12Garage2.Models.ViewModels
{
    public class VehicleCountByTypeViewModel
    {
        [DisplayName("Type of vehicle")]
        public string VehicleTyp { get; set; }

        [DisplayName("Number of vehicles")]
        public int VehicleCount { get; set; }
    }
}