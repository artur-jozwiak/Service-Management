using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public ServiceContext Context { get; set; }
        public List<Employee> EmployeeList { get; set; }
        public EmployeeRepository(ServiceContext context)
        {
            Context = context;
            EmployeeList = Context.Employees.ToList();
        }

        public void Add(Employee employee)
        {
            Context.Employees.Add(employee);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = GetById(id);
            Context.Employees.Remove(employee);
            Context.SaveChanges();
        }

        public Employee GetById(int id)
        {
            return EmployeeList.FirstOrDefault(e => e.Id == id);
        }

        public void Update(Employee model)
        {
            var employee = GetById(model.Id);
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.Salary = model.Salary;
            employee.Role = model.Role;
            Context.SaveChanges();
        }
    }
}
