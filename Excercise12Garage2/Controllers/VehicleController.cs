using Excercise12Garage2.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Excercise12Garage2.Controllers
{
    public class VehicleController : Controller
    {
        /// <summary>
        /// TODO GET TEST DATA
        /// REMOVE
        /// </summary>
        /// <param name="iAmountOfVehicles"></param>
        /// <returns></returns>
        private List<VehicleViewModel>GetVehicles(int iAmountOfVehicles)
        {
            DateTime dt = DateTime.Now;
            List<VehicleViewModel> lsVehicles = new List<VehicleViewModel>();

            for (int i = 1; i <= iAmountOfVehicles; i++)
            {
                lsVehicles.Add(new VehicleViewModel{ Id = i, RegistrationNumber = i.ToString(), Type = i.ToString(), TimeOfArrival = dt.AddHours(-i) });
            }

            return lsVehicles;
        }


        [HttpGet]
        public ActionResult SearchFor(string txtSearchRegistrationNumber)
        {
            List<VehicleViewModel> lsVehicles = GetVehicles(10);

            if (!String.IsNullOrWhiteSpace(txtSearchRegistrationNumber))
                lsVehicles = lsVehicles.Where(r => r.RegistrationNumber.Equals(txtSearchRegistrationNumber, StringComparison.OrdinalIgnoreCase)).ToList();

            return View("Index", lsVehicles);
        }


        // GET: VehicleController
        public ActionResult Index()
        {
            List<VehicleViewModel> lsVehicles = GetVehicles(10);
            return View(lsVehicles);
        }


        // GET: VehicleController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VehicleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VehicleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VehicleController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VehicleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
