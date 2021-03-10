using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Excercise12Garage2.Data;
using Excercise12Garage2.Models;

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

        // GET: Vehicles/Create
        public IActionResult ParkNewCar()
        {
            return View();
        }

        // POST: Vehicles/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ParkNewCar([Bind("id,VehicleType,RegNum,Color,Make,Model,NumOfWheels,TimeOfArrival")] VehicleEditViewModel newVehicle)
        {
            if (ModelState.IsValid)
            {
                //Create new Vehicle
                ParkedVehicle vehicle = new ParkedVehicle();

                vehicle.Id = newVehicle.Id;
                vehicle.VehicleType = newVehicle.VehicleType;
                vehicle.RegistrationNumber = newVehicle.RegNum;
                vehicle.Color = newVehicle.Color;
                vehicle.Make = newVehicle.Make;
                vehicle.Model = newVehicle.Model;
                vehicle.NumberOfWheels = newVehicle.NumOfWheels;
                vehicle.CheckIn = newVehicle.TimeOfArrival;

                _dbGarage.Add(vehicle);
                await _dbGarage.SaveChangesAsync();
                return RedirectToAction(nameof(Details), new { id = vehicle.Id });
            }
            return View(newVehicle);
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
        public async Task<IActionResult> Delete(int? id)
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
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
    }
}
