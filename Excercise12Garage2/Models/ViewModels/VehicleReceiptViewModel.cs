using Excercise12Garage2.Utils;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Excercise12Garage2.Models.ViewModels
{
    //[Serializable]
    public class VehicleReceiptViewModel
    {
        public int Id { get; set; }

        [DisplayName("Registrationnumber")]
        public string RegistrationNumber{ get; set; }

        [DisplayName("Type of vehicle")]
        public string Type { get; set; }

        [DisplayName("Time of arrival")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Parked time")]
        public string ParkedTime
        {
            get
            {
                return VehicleHelper.CalculateParkedTime(CheckIn);
            }
        }


        [DisplayName("Time of arrival")]
        public string TimeOfArrivalAsString
        {
            get
            {
                return CheckIn.ToShortDateString() + " " + CheckIn.ToShortTimeString();
            }
        }

        [DisplayName("Time of leaving")]
        public string TimeOfLeavingAsString
        {
            get
            {
                return DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString();
            }
        }

        [DisplayFormat(DataFormatString = "{0:C}")]
        [DisplayName("Price")]
        public double Price
        {
            get
            {
                return VehicleHelper.CalculatePrice(CheckIn);
            }
        }
    }
}
