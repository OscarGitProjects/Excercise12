using Excercise12Garage2.Models.ViewModels;
using Excercise12Garage2.Utils;
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
        public ActionResult Sort(string sortBy, string sortOrder, string txtSearchRegistrationNumber)
        {
            List<VehicleViewModel> lsVehicles = GetVehicles(10);

            if (String.IsNullOrWhiteSpace(sortOrder))
                sortOrder = "asc";

            if (!String.IsNullOrWhiteSpace(txtSearchRegistrationNumber))
            {
                txtSearchRegistrationNumber = txtSearchRegistrationNumber.Trim();
                ViewBag.SearchFor = txtSearchRegistrationNumber;
                lsVehicles = lsVehicles.Where(r => r.RegistrationNumber.Equals(txtSearchRegistrationNumber, StringComparison.OrdinalIgnoreCase)).ToList();            
            }

            // Sort list with vehicle
            lsVehicles = VehicleHelper.Sort(lsVehicles, sortBy, sortOrder);

            // Now set up sortOrder for next postback
            if (sortOrder.Equals("desc"))
                sortOrder = "asc";
            else
                sortOrder = "desc";


            // Set ViewBags
            ViewBag.SortOrder = sortOrder;
            ViewBag.OldSortBy = sortBy;

            return View("Index", lsVehicles);
        }

        [HttpGet]
        public ActionResult SearchFor(string sortOrder, string oldSortBy, string txtSearchRegistrationNumber)
        {
            List<VehicleViewModel> lsVehicles = GetVehicles(10);

            if (String.IsNullOrWhiteSpace(sortOrder))
                sortOrder = "asc";

            if (!String.IsNullOrWhiteSpace(txtSearchRegistrationNumber))
            {
                txtSearchRegistrationNumber = txtSearchRegistrationNumber.Trim();
                ViewBag.SearchFor = txtSearchRegistrationNumber;
                lsVehicles = lsVehicles.Where(r => r.RegistrationNumber.Equals(txtSearchRegistrationNumber, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            // Sort list with vehicle
            lsVehicles = VehicleHelper.Sort(lsVehicles, oldSortBy, sortOrder);


            // Set ViewBags
            ViewBag.SortOrder = sortOrder;
            ViewBag.OldSortBy = oldSortBy;

            return View("Index", lsVehicles);
        }


        // GET: VehicleController
        public ActionResult Index()
        {
            string sortOrder = "asc";
            string sortBy = "RegistrationNumber";

            List<VehicleViewModel> lsVehicles = GetVehicles(10);

            // Sort list with vehicle
            lsVehicles = VehicleHelper.Sort(lsVehicles, sortBy, sortOrder);


            // Set ViewBags
            ViewBag.SortOrder = sortOrder;
            ViewBag.OldSortBy = sortBy;

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
