using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories;

namespace Warsztat_v2.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;
        public ServiceContext Context { get; set; }

        public EmployeeController(ServiceContext serviceContext)
        {
            Context = serviceContext;
            _employeeRepository = new EmployeeRepository(serviceContext);
        }
        // GET: EmployeeControler
        public ActionResult Index()
        {
            var model = Context.Employees;
            return View(model);
        }

        // GET: EmployeeControler/Details/5
        public ActionResult Details(int id)
        {
            var model = _employeeRepository.GetById(id);
            return View(model);
        }

        // GET: EmployeeControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeControler/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _employeeRepository.Add(model);
                return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeControler/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _employeeRepository.GetById(id);
            return View(model);
        }

        // POST: EmployeeControler/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _employeeRepository.Update(model);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeControler/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _employeeRepository.GetById(id);
            return View(model);
        }

        // POST: EmployeeControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee model)
        {
            try
            {
                _employeeRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
