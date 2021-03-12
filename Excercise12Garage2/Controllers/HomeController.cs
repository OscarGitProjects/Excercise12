using Excercise12Garage2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Excercise12Garage2.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger
        /// I love summer and C#. And stuff. More stuff
        /// I am learning GIT in a very painful way ... 
        /// I love summer and C#
        /// Lite ändringar more
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Vehicles");
            //return View();

            // need to create a ViewModel to return view.

            // This is another update from me.
        }

        public IActionResult About()
        {
            
            return View();
            // need to create a ViewModel to return view. bla bla
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
