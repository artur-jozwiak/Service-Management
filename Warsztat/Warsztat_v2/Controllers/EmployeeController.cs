using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warsztat.BLL.Models;
using Warsztat.BLL.Services;

namespace Warsztat_v2.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;
        public EmployeeController()
        {
           _employeeService = new EmployeeService();
        }
        // GET: EmployeeControler
        public ActionResult Index()
        {
           var model = _employeeService.GetAll();
            return View(model);
        }

        // GET: EmployeeControler/Details/5
        public ActionResult Details(int id)
        {
            var model = _employeeService.GetById(id);
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
                _employeeService.Create(model);
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
            var model = _employeeService.GetById(id);
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
                _employeeService.Update(model);
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
            var model = _employeeService.GetById(id);
            return View(model);
        }

        // POST: EmployeeControler/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee model)
        {
            try
            {
                _employeeService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
