using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Excercise12Garage2.Data;
using Excercise12Garage2.Models;
using System.Globalization;
using Excercise12Garage2.Models.ViewModels;

namespace Excercise12Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Excercise12Garage2Context _dbGarage;

        public VehiclesController(Excercise12Garage2Context context)
        {
            _dbGarage = context;
        }

        // GET: Vehicles
        // Index Page listing all Vehicles in Garage
        public async Task<IActionResult> Index()
        {
            return View(await _dbGarage.Vehicle.ToListAsync());
        }

        // GET: Vehicles/Details/5
        // Details Page for Vehicle Parked in Garage
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _dbGarage.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Park new vehicle
        public IActionResult Park()
        {
            var vTypes = GetVehicleTypes();
            var model = new VehicleEditViewModel();
            model.VehicleTypes = GetVehicleTypeOptions(vTypes);
            return View(model);
        }

        
        // POST: Vehicles/Parks new vehicle
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park([Bind("id,VehicleType,RegNum,Color,Make,Model,NumOfWheels,TimeOfArrival")] VehicleEditViewModel newVehicle)
        {
           


            if (ModelState.IsValid)
            {
                //Create new Vehicle
                ParkedVehicle vehicle = new ParkedVehicle();
                

                vehicle.Id = newVehicle.Id;
                vehicle.VehicleType = newVehicle.VehicleType;
                vehicle.RegistrationNumber = newVehicle.RegistrationNumber;
                vehicle.Color = newVehicle.Color;
                vehicle.Make = newVehicle.Make;
                vehicle.Model = newVehicle.Model;
                vehicle.NumberOfWheels = newVehicle.NumberOfWheels;
                vehicle.CheckIn = newVehicle.CheckIn;

                _dbGarage.Add(vehicle);
                await _dbGarage.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = vehicle.Id });
            }
            return View(newVehicle);
        }

        private  IEnumerable<string> GetVehicleTypes()
        {
             
            return new List<string> 
                { 
                "Car",
                "Boat",
                "Motorcycle",
                "Airplane",
                "Bus",
                "Truck",
                "Sportscar",
            };
        }
        
        private IEnumerable<SelectListItem> GetVehicleTypeOptions(IEnumerable<string> elements)
        {
            var typeList = new List<SelectListItem>();
            foreach(var element in elements)
            {
                typeList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
            }
            return typeList;
        }

       
        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _dbGarage.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,VehicleType,RegNum,Color,Make,Model,NumOfWheels,TimeOfArrival")] ParkedVehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbGarage.Update(vehicle);
                    await _dbGarage.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        //Take Vehicle out of Garage
        public async Task<IActionResult> Remove(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _dbGarage.Vehicle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        // Confirm Vehicle out of Garage 
        //TODO, add link to Receipt Page
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            var vehicle = await _dbGarage.Vehicle.FindAsync(id);
            _dbGarage.Vehicle.Remove(vehicle);
            await _dbGarage.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _dbGarage.Vehicle.Any(e => e.Id == id);
        }

        //GET: Vehicles/Receipt/5
        // Get Receipt for Vehicle Parked in Garage

        public async Task<IActionResult> Receipt()
        {
            var model = _dbGarage.Vehicle.Select(v => new VehicleViewModel
            {
                Id = v.Id,
                RegistrationNumber = v.RegistrationNumber,
                TimeOfArrival = v.CheckIn,
                Type = v.VehicleType,

            });
            return View(await model.ToListAsync());
        }

        //public async Task<IActionResult> Receipt()
        //{
        //    ParkedVehicle parkedVehicle = TempData["parkedVehicle"] as ParkedVehicle;
        //    ViewBag.RegistrationNumber = parkedVehicle.RegistrationNumber;
        //    ViewBag.CheckIn = parkedVehicle.CheckIn;
        //    ViewBag.CheckOut = DateTime.Now;

        //    TimeSpan TotalTime = ViewBag.ChekOut.Subtract(ViewBag.CheckIn);
        //    ViewBag.TotalTime = String.Format("{0} days, {1} hour, {2} minutes", TotalTime.Days, TotalTime.Hours, TotalTime.Minutes);
        //    var price = Math.Floor(TotalTime.TotalMinutes * 3);
        //    ViewBag.TotalPrice = price.ToString(CultureInfo.CreateSpecificCulture("sv-SE"));

        //    return View();
        //}

        //public async Task<IActionResult> Receipt(VehicleViewModel viewModel)
        //{
        //    //ViewBag.Id = viewModel.Id;
        //    ViewBag.RegistrationNumber = viewModel.RegistrationNumber;
        //    ViewBag.TimeOfArrival = viewModel.TimeOfArrival;
        //    ViewBag.ParkedTime = viewModel.ParkedTime;
        //    var Price = viewModel.Price;
        //    ViewBag.Price = Price.ToString(CultureInfo.CreateSpecificCulture("sv-SE"));

        //    return View("Receipt", viewModel);

        //}

    }
}
