using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Models;
using Warsztat.BLL.Services;


namespace Warsztat_v2.Controllers
{
    public class PartController : Controller
    {
        private PartService _partService;
        public PartController()
        {
            _partService = new PartService();
        }
        // GET: PartController1
        public ActionResult Index()
        {
            var model = _partService.GetAll();
            return View(model);
        }

        // GET: PartController1/Details/5
        public ActionResult Details(int id)
        {
            var model = _partService.GetById(id);
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
        public ActionResult Create(Part model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _partService.Create(model);

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
            var model = _partService.GetById(id);
            return View(model);
        }

        // POST: PartController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Part model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                _partService.Update(model);
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
            var model = _partService.GetById(id);
            return View(model);
        }

        // POST: PartController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Part model)
        {
            try
            {
                _partService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
