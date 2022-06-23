using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Enums;
using Warsztat.BLL.Models;
using Warsztat.BLL.Services.Interfaces;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Controllers
{

    public class OrderController : Controller
    {
        public ServiceContext Context { get; set; }

        private IOrderRepository _orderRepository;
        private ICarRepository _carRepository;//
        private IEmployeeRepository _employeeRepository;//
        private IPartService _partService;//

        public OrderController(IOrderRepository orderRepository, IPartService partRepository, ICarRepository carRepository, IEmployeeRepository employeeRepository, ServiceContext serviceContext)
        {
            _orderRepository = orderRepository;
            _partService = partRepository;//
            _carRepository = carRepository;//
            _employeeRepository = employeeRepository;//
            Context = serviceContext;
        }
        // GET: OrderController
        public ActionResult Index(string sortOrder, string searchStringForClient, string searchStringForOrderNumber, string searchStringForMechanic)
        {
            var model = Context.Orders;
            return View(model);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            var model = _orderRepository.GetById(id);
            return View(model);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            ViewBag.Cars = Context.Cars.ToList();
            ViewBag.Parts = Context.Parts.ToList();
            ViewBag.Mechanics = Context.Employees.Where(e => e.Role == Role.Mechanic).ToList();
            //ViewBag.Employees = _employeeService.GetAll().ToList();

            //var model = new CreateOrderViewModel()
            //{
            //    Cars = _carrService.GetAll(),
            //    Parts = _partService.GetAll(),
            //    Employees = _employeeService.GetAll().Where(e => e.Role == Role.Mechanic).ToList()
            //};

            return View(/*model*/);

        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order model)
        {
            try
            {
                model.OrderNumber = _orderRepository.OrderNumberGenerator(model);
                _orderRepository.Add(model);
                if (ModelState.IsValid)
                {
                    return View(model);
                }
                // _orderService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Cars = Context.Cars.ToList();
            ViewBag.Parts = Context.Parts.ToList();
            ViewBag.Mechanics = Context.Employees.Where(m => m.Role == Role.Mechanic).ToList();


            var model = _orderRepository.GetById(id);
            return View(model);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return View(model);
                }
                _orderRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _orderRepository.GetById(id);
            return View(model);
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order model)
        {
            try
            {
                _orderRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
