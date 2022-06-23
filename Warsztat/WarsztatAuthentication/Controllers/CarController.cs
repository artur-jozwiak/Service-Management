using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories;



namespace Warsztat_v2.Controllers
{
    public class CarController : Controller
    {
        private readonly CarRepository _carRepository;
        public ServiceContext Context { get; set; }
        public CarController(ServiceContext serviceContext)
        {
            Context = serviceContext;
            _carRepository = new CarRepository(Context);
            SelectList list = new SelectList(Context.Cars, "CarModel", "CarMark");
            ViewBag.Roles = list;
        }
        // GET: CarrController
        public ActionResult Index()
        {
            var model = Context.Cars;
            return View(model);
        }

        // GET: PartController1/Details/5
        public ActionResult Details(int id)
        {
            var model = _carRepository.GetById(id);
            return View(model);
        }

        // GET: PartController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Car model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _carRepository.Add(model);

                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: PartController1/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _carRepository.GetById(id);
            return View(model);
        }

        // POST: PartController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Car model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _carRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PartController1/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _carRepository.GetById(id);
            return View(model);
        }

        // POST: PartController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Car model)
        {
            try
            {
                _carRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
