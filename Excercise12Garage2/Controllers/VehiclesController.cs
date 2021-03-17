using Excercise12Garage2.Data;
using Excercise12Garage2.Models;
using Excercise12Garage2.Models.ViewModels;
using Excercise12Garage2.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excercise12Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Excercise12Garage2Context _dbGarage;

        public VehiclesController(Excercise12Garage2Context context)
        {
            _dbGarage = context;
        }


        [HttpGet]
        public ActionResult Sort(string sortBy, string sortOrder, string txtSearchRegistrationNumber)
        {
            List<VehicleViewModel> lsVehicles = null;

            if (String.IsNullOrWhiteSpace(sortOrder))
                sortOrder = "asc";

            if (!String.IsNullOrWhiteSpace(txtSearchRegistrationNumber))
            {
                txtSearchRegistrationNumber = txtSearchRegistrationNumber.Trim();
                txtSearchRegistrationNumber = txtSearchRegistrationNumber.ToLower();
                ViewBag.SearchFor = txtSearchRegistrationNumber;
                lsVehicles = _dbGarage.Vehicle.Where(r => r.RegistrationNumber.ToLower().Equals(txtSearchRegistrationNumber))
                    .Select
                    (v => new VehicleViewModel{ 
                        Id = v.Id,
                        RegistrationNumber = v.RegistrationNumber,
                        TimeOfArrival = v.CheckIn,
                        Type = v.VehicleType
                    })
                    .ToList<VehicleViewModel>();
            }
            else
            {
                lsVehicles = _dbGarage.Vehicle
                    .Select
                    (v => new VehicleViewModel
                    {
                        Id = v.Id,
                        RegistrationNumber = v.RegistrationNumber,
                        TimeOfArrival = v.CheckIn,
                        Type = v.VehicleType
                    })
                    .ToList<VehicleViewModel>();
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

            return View("Garage", lsVehicles);
        }


        [HttpGet]
        public ActionResult SearchFor(string sortOrder, string oldSortBy, string txtSearchRegistrationNumber)
        {
            List<VehicleViewModel> lsVehicles = null;

            if (String.IsNullOrWhiteSpace(sortOrder))
                sortOrder = "asc";

            if (!String.IsNullOrWhiteSpace(txtSearchRegistrationNumber))
            {
                txtSearchRegistrationNumber = txtSearchRegistrationNumber.Trim();
                txtSearchRegistrationNumber = txtSearchRegistrationNumber.ToLower();

                ViewBag.SearchFor = txtSearchRegistrationNumber;
                lsVehicles = _dbGarage.Vehicle.Where(r => r.RegistrationNumber.ToLower().Equals(txtSearchRegistrationNumber))
                   .Select
                    (v => new VehicleViewModel
                    {
                        Id = v.Id,
                        RegistrationNumber = v.RegistrationNumber,
                        TimeOfArrival = v.CheckIn,
                        Type = v.VehicleType
                    })
                    .ToList<VehicleViewModel>();
            }
            else
            {
                lsVehicles = _dbGarage.Vehicle
                    .Select
                    (v => new VehicleViewModel
                    {
                        Id = v.Id,
                        RegistrationNumber = v.RegistrationNumber,
                        TimeOfArrival = v.CheckIn,
                        Type = v.VehicleType
                    })
                    .ToList<VehicleViewModel>();
            }

            // Sort list with vehicle
            lsVehicles = VehicleHelper.Sort(lsVehicles, oldSortBy, sortOrder);

            // Set ViewBags
            ViewBag.SortOrder = sortOrder;
            ViewBag.OldSortBy = oldSortBy;

            return View("Garage", lsVehicles);
        }


        // GET: VehicleController
        public ActionResult Garage()
        {
            string sortOrder = "asc";
            string sortBy = "RegistrationNumber";

            List<VehicleViewModel> lsVehicles = _dbGarage.Vehicle
                .Select
                    (v => new VehicleViewModel
                    {
                        Id = v.Id,
                        RegistrationNumber = v.RegistrationNumber,
                        TimeOfArrival = v.CheckIn,
                        Type = v.VehicleType
                    })
                    .ToList<VehicleViewModel>();

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

            return View(lsVehicles);
        }



        // GET: Vehicles
        // Index Page listing all Vehicles in Garage
        public async Task<IActionResult> Index()
        {
            var messageObject = TempData["message"];
            if(messageObject != null)
            {
                ViewBag.Message = messageObject as string;
            }

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
            model.IsGarageFull = IsGarageFull();
            return View(model);
        }

        /// <summary>
        /// Method check i garage is full or not
        /// </summary>
        /// <returns>true if garage is full. Else false</returns>
        private bool IsGarageFull()
        {
            bool bFull = false;
            int iNumberOfFreeParkingPlaces = 0;

            // Hämta antal fordon i garaget
            int numberOfVehicles = _dbGarage.Vehicle.Count();

            // Hämta garaget
            var garage = _dbGarage.Garage.FirstOrDefault();
            if(garage != null)
                iNumberOfFreeParkingPlaces = garage.NumberOfParkingPlaces - numberOfVehicles;

            bFull = iNumberOfFreeParkingPlaces <= 0 ? true : false;
            return bFull;
        }

        
        // POST: Vehicles/Parks new vehicle
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Park([Bind("VehicleType,RegistrationNumber,Color,Make,Model,NumberOfWheels")] VehicleEditViewModel newVehicle)
        {          
            if (ModelState.IsValid)
            {
                
                bool bRegistrationNumberExist = CheckIfRegistrationNumberExist(newVehicle.RegistrationNumber);

                if (bRegistrationNumberExist)
                {
                    ModelState.AddModelError("Registrationnumber", "Registrationnumber already exist");

                    var vTypes = GetVehicleTypes();
                    newVehicle.VehicleTypes = GetVehicleTypeOptions(vTypes);
                }
                else
                {
                    //Create new Vehicle
                    ParkedVehicle vehicle = new ParkedVehicle();
                    //vehicle.Id = newVehicle.Id;
                    vehicle.VehicleType = newVehicle.VehicleType;
                    vehicle.RegistrationNumber = newVehicle.RegistrationNumber;
                    vehicle.Color = newVehicle.Color;
                    vehicle.Make = newVehicle.Make;
                    vehicle.Model = newVehicle.Model;
                    vehicle.NumberOfWheels = newVehicle.NumberOfWheels;
                    vehicle.CheckIn = DateTime.Now;


                    _dbGarage.Add(vehicle);
                    await _dbGarage.SaveChangesAsync();
                    TempData["message"] = $"You have succesfully parked your {vehicle.VehicleType}!";
                    return RedirectToAction(nameof(Details), new { id = vehicle.Id });
                }
            }

            return View(newVehicle);
        }


        /// <summary>
        /// Method check if a vehicle with registrationnumber already exist or not
        /// If id is < 0 then we dont check if it is the same vehicle
        /// </summary>        
        /// <param name="strRegistrationNumber">Registrationnumber</param>
        /// <param name="id">Id for vehicle. Deafult is -1</param>
        /// <returns>true if registrationnumber exist. Otherwise false</returns>
        public bool CheckIfRegistrationNumberExist(string strRegistrationNumber, int id = -1)
        {
            bool bExist = false;

            if (!String.IsNullOrWhiteSpace(strRegistrationNumber))
            {
                strRegistrationNumber = strRegistrationNumber.Trim();
                strRegistrationNumber = strRegistrationNumber.ToLower();
                var vehicle = _dbGarage.Vehicle.AsNoTracking().Where(r => r.RegistrationNumber.ToLower().Equals(strRegistrationNumber)).FirstOrDefault();

                if(id < 0)
                {
                    if (vehicle != null)
                        bExist = true;
                }
                else
                {
                    if (vehicle != null && vehicle.Id != id)
                        bExist = true;
                }
            }

            return bExist;
        }

        //[AcceptVerbs("GET", "POST")]
        public JsonResult IfRegistrationNumberNotExist(string RegistrationNumber, int Id = -1)
        {
            bool bNotExist = true;

            if (!String.IsNullOrWhiteSpace(RegistrationNumber))
            {
                RegistrationNumber = RegistrationNumber.Trim();
                RegistrationNumber = RegistrationNumber.ToLower();
                var vehicle = _dbGarage.Vehicle.AsNoTracking().Where(r => r.RegistrationNumber.ToLower().Equals(RegistrationNumber)).FirstOrDefault();

                if (Id < 0)
                {
                    if (vehicle != null)
                        bNotExist = false;
                }
                else
                {
                    if (vehicle != null && vehicle.Id == Id)
                        bNotExist = true;
                }
            }

            return Json(bNotExist);
        }

        //List of Vehicle Types for Dropdown in Park
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
        
        //Creates Enumerable List for Dropdown
        private IEnumerable<SelectListItem> GetVehicleTypeOptions(IEnumerable<string> elements, string selectedValue = "")
        {
            var typeList = new List<SelectListItem>();
            foreach(var element in elements)
            {
                bool IsNullOrWhiteSpace = String.IsNullOrWhiteSpace(selectedValue);

                typeList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element,
                    Selected = (!IsNullOrWhiteSpace && element.Equals(selectedValue)) ? true : false
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

            var vehicle = await _dbGarage.Vehicle.Select(v => new VehicleEditViewModel
            {
                CheckIn = v.CheckIn,
                Id = v.Id,
                Color = v.Color,
                Make = v.Make,
                Model = v.Model,
                NumberOfWheels = v.NumberOfWheels,
                RegistrationNumber = v.RegistrationNumber,
                VehicleType = v.VehicleType
            })
            .FirstOrDefaultAsync(i => i.Id == id);
            

            if (vehicle == null)
            {
                return NotFound();
            }

            var vTypes = GetVehicleTypes();
            vehicle.VehicleTypes = GetVehicleTypeOptions(vTypes, vehicle.VehicleType);

            // VehicleEditViewModel
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,VehicleType,RegistrationNumber,Color,Make,Model,NumberOfWheels")] VehicleEditViewModel upDatedVehicle)
        {
            if (Id != upDatedVehicle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                bool bRegistrationNumberExist = CheckIfRegistrationNumberExist(upDatedVehicle.RegistrationNumber, upDatedVehicle.Id);

                if (bRegistrationNumberExist)
                {
                    ModelState.AddModelError("Registrationnumber", "Registration number already exist");
                }
                else
                {
                    try
                    {
                        // Update Vehicle
                        ParkedVehicle vehicle = new ParkedVehicle();
                        vehicle.Id = upDatedVehicle.Id;
                        vehicle.VehicleType = upDatedVehicle.VehicleType;
                        vehicle.RegistrationNumber = upDatedVehicle.RegistrationNumber;
                        vehicle.Color = upDatedVehicle.Color;
                        vehicle.Make = upDatedVehicle.Make;
                        vehicle.Model = upDatedVehicle.Model;
                        vehicle.NumberOfWheels = upDatedVehicle.NumberOfWheels;
                        //vehicle.CheckIn = DateTime.Now;

                        _dbGarage.Vehicle.Attach(vehicle).State = EntityState.Modified;
                        _dbGarage.Entry(vehicle).Property(c => c.CheckIn).IsModified = false;
                        await _dbGarage.SaveChangesAsync();

                        TempData["message"] = "You have updated information about the vehicle " + vehicle.RegistrationNumber;
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!VehicleExists(upDatedVehicle.Id))
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
            }
            return View(upDatedVehicle);
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


        // GET: Vehicles/Statistics/5
        //Statisctics
        public async Task<IActionResult> Statistics()
        {
            VehicleStatisticsViewModel viewModel = new VehicleStatisticsViewModel();

            // Count number of vehicles in the garage
            viewModel.NumberOfVehiclesInGarage = await _dbGarage.Vehicle.CountAsync();


            // Calculate number of wheels att vehicles in the garage
            var sumOfWheels = await _dbGarage.Vehicle.SumAsync(v => v.NumberOfWheels);            
            viewModel.SumOfWheels = sumOfWheels;


            // Calculate total revenue for vehicles in the garage
            DateTime dtNow = DateTime.Now;
            int iPricePerMinute = 3;
            var sum = await _dbGarage.Vehicle.SumAsync(c => EF.Functions.DateDiffMinute(c.CheckIn, dtNow) * iPricePerMinute);
            viewModel.TotalRevenue = sum;

            //double dblTotalMinutes = 0.0;
            //var vehicles = _dbGarage.Vehicle.ToList();
            //foreach(var vehicle in vehicles)
            //    dblTotalMinutes += Math.Round((dtNow - vehicle.CheckIn).TotalMinutes) * iPricePerMinute;

            //viewModel.TotalRevenue = dblTotalMinutes;


            // Calculate number of vehicles in every group of vehicles
            viewModel.VehicleCountByType = _dbGarage.Vehicle
                .GroupBy(t => t.VehicleType)
                .Select(group => new VehicleCountByTypeViewModel
                {
                    VehicleTyp = group.Key,
                    VehicleCount = group.Count()
                })
                .OrderBy(t => t.VehicleTyp)
                .ToList();

            return View(viewModel);
        }

        // POST: Vehicles/Delete/5
        // Confirm Vehicle out of Garage 
        //TODO, add link to Receipt Page
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(int id)
        {
            VehicleReceiptViewModel receipt = null;

            var vehicle = await _dbGarage.Vehicle.FindAsync(id);
            if(vehicle != null)
            {
                receipt = new VehicleReceiptViewModel();
                receipt.CheckIn = vehicle.CheckIn;
                receipt.Id = vehicle.Id;
                receipt.RegistrationNumber = vehicle.RegistrationNumber;
                receipt.Type = vehicle.VehicleType;
            }

            //TempData["Reciept"] = JsonConvert.SerializeObject(receipt);

            _dbGarage.Vehicle.Remove(vehicle);
            await _dbGarage.SaveChangesAsync();
            TempData["message"] = $"You have successfully removed your {vehicle.VehicleType}!";
            return View("Receipt", receipt);
            //return RedirectToAction(nameof(Receipt));
        }

        private bool VehicleExists(int id)
        {
            return _dbGarage.Vehicle.Any(e => e.Id == id);
        }
    }
}
