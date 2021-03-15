using Excercise12Garage2.Data;
using Excercise12Garage2.Models;
using Excercise12Garage2.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;

namespace Excercise12Garage2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Excercise12Garage2Context _dbGarage;

        public HomeController(ILogger<HomeController> logger, Excercise12Garage2Context context)
        {
            _logger = logger;
            _dbGarage = context;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel();

            var garage = _dbGarage.Garage.FirstOrDefault();
            if (garage != null)
            {
                viewModel.GarageName = garage.Name;
                viewModel.NumberOfParkingPlaces = garage.NumberOfParkingPlaces;
                viewModel.NumberOfVehiclesInGarage = _dbGarage.Vehicle.Count();
            }

            return View(viewModel);
        }

        public IActionResult About()
        {
            
            return View();
            // need to create a ViewModel to return view. bla bla
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
