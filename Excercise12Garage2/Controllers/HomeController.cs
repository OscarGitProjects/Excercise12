using Excercise12Garage2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise12Garage2.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Logger
        /// I am learning GIT in a very painful way ... 
        /// </summary>
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();

            // need to create a ViewModel to return view.

            // This is another update from me.
        }

        public IActionResult Privacy()
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
