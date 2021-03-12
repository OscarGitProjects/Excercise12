using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Excercise12Garage2.Models.ViewModels
{
    public class VehicleStatisticsViewModel
    {
        public int Id { get; set; }

        [DisplayName("Sum of wheels")]
        public int SumOfWheels { get; set; }

        [DisplayName("Total Revenue")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double TotalRevenue { get; set; }
    }
}
