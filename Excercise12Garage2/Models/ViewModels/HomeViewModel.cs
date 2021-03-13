namespace Excercise12Garage2.Models.ViewModels
{
    public class HomeViewModel
    {
        public string GarageName { get; set; }
        public int NumberOfParkingPlaces { get; set; }
        public int NumberOfVehiclesInGarage { get; internal set; }
    }
}
