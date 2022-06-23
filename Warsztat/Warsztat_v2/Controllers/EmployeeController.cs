using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly ServiceContext _context;
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(ServiceContext context, IEmployeeRepository employeeRepository)
        {
            _context = context;
            _employeeRepository = employeeRepository;
        }

        // GET: Employees
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.RoleSortParm = sortOrder == "Role" ? "role_desc" : "Role";
            ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "firstName_desc" : "FirstName";
            var emploees = from e in _context.Employees select e;
            switch (sortOrder)
            {
                case "name_desc":
                    emploees = emploees.OrderByDescending(e => e.LastName);
                    break;
                case "FirstName":
                    emploees = emploees.OrderBy(e => e.FirstName);
                    break;
                case "firstName_desc":
                    emploees = emploees.OrderByDescending(e => e.FirstName);
                    break;
                case "Role":
                    emploees = emploees.OrderBy(e => e.Role);
                    break;
                case "role_desc":
                    emploees = emploees.OrderByDescending(e => e.Role);
                    break;
                default:
                    emploees = emploees.OrderBy(e => e.LastName);
                    break;
            }
            ClearTable();
            _employeeRepository.AddFinishedOrder();
            _context.SaveChanges();

            return View(await emploees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult>  Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            //return View(employee);
            return  Ok(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,DateOfBirth,Salary,Role,FinishedOrder")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,DateOfBirth,Salary,Role,FinishedOrder")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }
                _employeeRepository.Update(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
        private void ClearTable()
        {
            foreach (var finishedOrders in _context.Employees)
            {
                var employee = _context.Employees.First(e => e.Id == finishedOrders.Id);
                employee.FinishedOrder = 0;
            }
        }
    }

}
