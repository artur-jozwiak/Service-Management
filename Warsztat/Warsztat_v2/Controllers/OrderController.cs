using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Warsztat.BLL.Enums;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
//using Warsztat.BLL.Models;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Controllers
{
   // [ApiController]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly ServiceContext _context;
        private readonly IOrderRepository _orderRepository;
        VehicleResponse _vehicleResponse = new VehicleResponse();

     

        public OrderController(ServiceContext context, IOrderRepository orderRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
        }

        // GET: Orders
        public async Task<IActionResult> Index(string sortOrder, string searchStringForClient, string searchStringForOrderNumber, string searchStringForMechanic)
        {

            var model = _context.Orders
              .Include(o => o.Car)
              .Include(o => o.Mechanic)
              .ToList();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.WaitingStatus = sortOrder == "Status" ? "WaitingStatus" : "Status";
            ViewBag.VerivicationStatus = sortOrder == "Status" ? "VerivicationStatus" : "Status";
            ViewBag.InProgressStatus = sortOrder == "Status" ? "InProgressStatus" : "Status";
            ViewBag.FinishedStatus = sortOrder == "Status" ? "FinishedStatus" : "Status";
            ViewBag.CancelledStatus = sortOrder == "Status" ? "CancelledStatus" : "Status";
            ViewBag.TotalOrders = sortOrder == "Status" ? "TotalOrders" : "Status";

            var orders = from o in model
                         select o;

            if (!String.IsNullOrEmpty(searchStringForClient))
            {
                orders = orders.Where(o => o.Client.ToUpper().Contains(searchStringForClient.ToUpper()));
            }
            if (!String.IsNullOrEmpty(searchStringForOrderNumber))
            {
                orders = orders.Where(o => o.OrderNumber.ToString().ToUpper().Contains(searchStringForOrderNumber.ToUpper()));
            }
            if (!String.IsNullOrEmpty(searchStringForMechanic))
            {
                orders = orders.Where(o => o.Mechanic.FullName.ToUpper().Contains(searchStringForMechanic.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    orders = orders.OrderByDescending(o => o.Client);
                    break;
                case "Date":
                    orders = orders.OrderBy(o => o.StartTime);
                    break;
                case "date_desc":
                    orders = orders.OrderByDescending(o => o.StartTime);
                    break;
                case "WaitingStatus":
                    orders = orders.Where(o => o.Status == Status.Waiting);
                    break;
                case "VerivicationStatus":
                    orders = orders.Where(o => o.Status == Status.Verification);
                    break;
                case "InProgressStatus":
                    orders = orders.Where(o => o.Status == Status.InProgress);
                    break;
                case "FinishedStatus":
                    orders = orders.Where(o => o.Status == Status.Finished);
                    break;
                case "CancelledStatus":
                    orders = orders.Where(o => o.Status == Status.Cancelled);
                    break;
                case "TotalOrders":
                    orders = model.ToList();
                    break;
                default:
                    orders = orders.OrderBy(o => o.Client);
                    break;
            }
            return View(orders);
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.Mechanic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        public string GetMakeName()
        {
            string makeName = "";
            return makeName;
        }

        //[HttpGet("/vehicle")]
        // GET: Orders/Create
        public async Task<IActionResult> Create(/*string carMark = ""*/)
        {
            
            var client = new HttpClient();
            var response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api//vehicles/GetMakesForVehicleType/car?format=json");
            var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>();
            var carsMakes = vehicleResponse.Results.OrderBy(c => c.MakeName);
            ViewBag.CarMark = new SelectList((System.Collections.IEnumerable)carsMakes, "MakeName", "MakeName");
 
            //var responseForModel = await client.GetAsync($"https://vpic.nhtsa.dot.gov/api//vehicles/GetModelsForMake/0?format=json");
            //var vehicleResponseForModel = await responseForModel.Content.ReadFromJsonAsync<VehicleResponse>();
            //var carsModels = vehicleResponseForModel.Results.OrderBy(c => c.Model_Name);
            //ViewData["CarModel"] = new SelectList((System.Collections.IEnumerable)carsModels, "Model_Name", "Model_Name");

            ViewData["MechanicId"] = new SelectList(_context.Employees.Where(e => e.Role == Role.Mechanic), "Id", "FullName");

            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderNumber,StartTime,WorkTime,EndTime,Status,Fault,Client,RegistrationNumber,CarId,MechanicId,Price")] Order order)
        {
            //if (ModelState.IsValid)
            {
                //_context.Add(order);
                _orderRepository.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var client = new HttpClient();
            var response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api//vehicles/GetMakesForVehicleType/car?format=json");
            var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>();
            var carsMakes = vehicleResponse.Results.OrderBy(c => c.MakeName);
            ViewBag.CarMark = new SelectList((System.Collections.IEnumerable)carsMakes, "MakeName", "MakeName");
            ViewData["MechanicId"] = new SelectList(_context.Employees.Where(e => e.Role == Role.Mechanic), "Id", "FullName", order.MechanicId);
            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }


            var client = new HttpClient();
            var response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api//vehicles/GetMakesForVehicleType/car?format=json");
            var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>();
            var carsMakes = vehicleResponse.Results.OrderBy(c => c.MakeName);
            ViewBag.CarMark = new SelectList((System.Collections.IEnumerable)carsMakes, "MakeName", "MakeName");
            ViewData["MechanicId"] = new SelectList(_context.Employees.Where(e => e.Role == Role.Mechanic), "Id", "FullName", order.MechanicId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderNumber,StartTime,WorkTime,EndTime,Status,Fault,Client,RegistrationNumber,CarId,MechanicId,Price")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            {
                try
                {
                    //_context.Update(order);
                    _orderRepository.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            var client = new HttpClient();
            var response = await client.GetAsync("https://vpic.nhtsa.dot.gov/api//vehicles/GetMakesForVehicleType/car?format=json");
            var vehicleResponse = await response.Content.ReadFromJsonAsync<VehicleResponse>();
            var carsMakes = vehicleResponse.Results.OrderBy(c => c.MakeName);
            ViewBag.CarMark = new SelectList((System.Collections.IEnumerable)carsMakes, "MakeName", "MakeName");
            ViewData["MechanicId"] = new SelectList(_context.Employees.Where(e => e.Role == Role.Mechanic), "Id", "FullName", order.MechanicId);
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Car)
                .Include(o => o.Mechanic)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
        public async Task<IActionResult> CreateForCarModel(string makeName )
        {
            var client = new HttpClient();
            var responseForModel = await client.GetAsync($"https://vpic.nhtsa.dot.gov/api//vehicles/GetModelsForMake/{makeName}?format=json");
            var vehicleResponseForModel = await responseForModel.Content.ReadFromJsonAsync<VehicleResponse>();
            var carsModels = vehicleResponseForModel.Results.OrderBy(c => c.Model_Name);
            ViewData["CarModel"] = new SelectList((System.Collections.IEnumerable)carsModels, "Model_Name", "Model_Name");

            return View();
        }
    }
}
