using Excercise12Garage2.Utils;
using System;
using System.ComponentModel;

namespace Excercise12Garage2.Models.ViewModels
{
    public class VehicleViewModel
    {
        public int Id { get; set; }

        [DisplayName("Type of vehicle")]
        public string Type { get; set; }

        [DisplayName("Registrationnummber")]
        public string RegistrationNumber { get; set; }

        public DateTime TimeOfArrival { get; set; }

        [DisplayName("Time of arrival")]
        public string TimeOfArrivalAsString
        {
            get
            {
                return TimeOfArrival.ToShortDateString() + " " + TimeOfArrival.ToShortTimeString();
            }
        }

        [DisplayName("Parked time")]
        public string ParkedTime 
        {
            get
            {
                return VehicleHelper.CalculateParkedTime(TimeOfArrival);
            }
        }        
    }
}
