using Excercise12Garage2.Utils;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Excercise12Garage2.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Type of Vehicle")]
        public string Type { get; set; }

        [DisplayName("Registration Number")]
        public string RegistrationNumber { get; set; }

        [DisplayName("Time of arrival")]
        public DateTime TimeOfArrival { get; set; }

        [DisplayName("Time of Arrival")]
        public string TimeOfArrivalAsString
        {
            get
            {
                return TimeOfArrival.ToShortDateString() + " " + TimeOfArrival.ToShortTimeString();
            }
        }

        [DisplayName("Parked Time")]
        public string ParkedTime 
        {
            get
            {
                return VehicleHelper.CalculateParkedTime(TimeOfArrival);
            }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Price")]
        public double Price
        {
            get
            {
                return VehicleHelper.CalculatePrice(TimeOfArrival);
            }
        }
    }
}
