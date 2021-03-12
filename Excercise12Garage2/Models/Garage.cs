using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Excercise12Garage2.Models
{
    public class Garage
    {
        [Key]
        public int GaregeId { get; set; }
        public string Name { get; set; }
        public int NumberOfParkingPlaces { get; set; }
        public virtual ICollection<VehicleParkingPlace> VehicleParkingPlace { get; set; }

        [NotMapped]
        public int NumberOfFreeParkingPlaces { get; set; }

        [NotMapped]
        public VehicleParkingPlace[,] VehicleParkingPlaces { get; set; }

        /*
         new VehicleParkingPlace[6,3];
        |1| |2| |3|
        --------
        |4| |5| |6|
        |7| |8| |9|
        -------
        |10| |11| |12|
        */
    }
}
