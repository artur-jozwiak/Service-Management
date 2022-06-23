using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories;

namespace Warsztat_v2.Controllers
{
    public class PartController : Controller
    {
        private readonly PartRepository _partRepository;
        public ServiceContext Context { get; set; }
        public PartController(ServiceContext serviceContext)
        {
            Context = serviceContext;
            _partRepository = new PartRepository(Context);
        }

        // GET: PartController1
        public ActionResult Index()
        {
            var model = Context.Parts;
            return View(model);
        }

        // GET: PartController1/Details/5
        public ActionResult Details(int id)
        {
            var model = _partRepository.GetById(id);
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
                _partRepository.Add(model);

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
            var model = _partRepository.GetById(id);
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
                _partRepository.Update(model);
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
            var model = _partRepository.GetById(id);
            return View(model);
        }

        // POST: PartController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Part model)
        {
            try
            {
                _partRepository.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
