using Warsztat.BLL.Enums;
using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ServiceContext _context;
        public List<Employee> Employees { get; set; }
        public List<Order> Orders { get; set; }
        public EmployeeRepository(ServiceContext context)
        {
            _context = context;
            Employees = _context.Employees.ToList();
            Orders = _context.Orders.ToList();
            //var postAll = blogs.SelectMany(b => b.Posts).Select(b => b.Subject).Distinct();
            //var json1 = Newtonsoft.Json.JsonConvert.SerializeObject(postAll);

        }

        public void AddFinishedOrder()
        {

            if (Employees == null)
            {
                Console.WriteLine("Empty Mechanic List"); 
            }
            var mechanicId = 0;
            foreach (var order in _context.Orders)
            {
                if (order.Status != Status.Finished)
                {

                }
                else
                {
                    mechanicId = order.MechanicId;
                    var employee = _context.Employees.First(e => e.Id == mechanicId);
                    employee.FinishedOrder++;
                }

            }
            _context.SaveChanges();
        }
        public string DisplayName()
        {
            var bestEmployeeList = _context.Employees.Where(e => e.FinishedOrder == HowManyFinishedOrder())
                .Select(e => e.FullName)
                .ToList();
            string result = string.Join(", ", bestEmployeeList);

            return result;
        }
        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            //_context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee model)
        {
            var employee = GetById(model.Id);
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            //employee.DateOfBirth = model.DateOfBirth;
            employee.Salary = model.Salary;
            employee.Role = model.Role;
            _context.SaveChanges();
        }
        public int HowManyFinishedOrder()
        {
            if (Employees == null)
            {
                Console.WriteLine("Empty Mechanic List");
            }
            var result = _context.Employees.OrderByDescending(e => e.FinishedOrder)
                .FirstOrDefault().FinishedOrder;
            return result;
        }
        public void ClearTable()
        {
            foreach (var finishedOrders in _context.Employees)
            {
                var employee = _context.Employees.First(e => e.Id == finishedOrders.Id);
                employee.FinishedOrder = 0;
            }
        }

    }

}
