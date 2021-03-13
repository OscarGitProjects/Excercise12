using System.ComponentModel.DataAnnotations;

namespace Excercise12Garage2.Models
{
    public class VehicleParkingPlace
    {
        [Key]
        public int ParkingPlaceId { get; set; }
        public bool IsAvailableParkingPlace { get; set; }
        public bool IsFreeParkingPlace { get; set; }        
        public bool IsHandicapped { get; set; }

        /// <summary>
        /// Id for parkedvehicles
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Parkedvehicles
        /// </summary>
        public virtual ParkedVehicle Vehicle { get; set; }
    }
}