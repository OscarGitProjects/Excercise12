using Excercise12Garage2.Utils;
using System;

namespace Excercise12Garage2.Models.ViewModels
{
    //[Serializable]
    public class VehicleReceiptViewModel
    {
        public int Id { get; set; }
        public string RegistrationNumber{ get; set; }
        public string Type { get; set; }
        public DateTime CheckIn { get; set; }

        /*
        public string ParkedTime
        {
            get
            {
                return VehicleHelper.CalculateParkedTime(CheckIn);
            }
        }

        public string Price
        {
            get
            {
                return VehicleHelper.CalculatePrice(CheckIn);
            }
        }*/
    }
}
