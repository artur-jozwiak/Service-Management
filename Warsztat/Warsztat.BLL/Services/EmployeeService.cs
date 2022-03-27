using System.Text.Json;
using Warsztat.BLL.Enums;
using Warsztat.BLL.Models;

namespace Warsztat.BLL.Services
{
    public class EmployeeService
    {
        private static List<Employee> Employees = new List<Employee>
        {
            new Employee()
            {
                Id = 1,
                FirstName = "Kuba",
                LastName = "Powiatowy",
                DateOfBirth = DateTime.Now.AddYears(-29),
                Salary = 3245.23,
                Role = Role.Mechanic
            },
            new Employee()
            {
                Id = 2,
                FirstName = "Jaroslaw",
                LastName = "Polskezbawsky",
                DateOfBirth = DateTime.Now.AddYears(-66),
                Salary = 168998.99,
                Role = Role.Manager
            },
            new Employee()
            {
                Id = 3,
                FirstName = "Kasia",
                LastName = "Liczypiórka",
                DateOfBirth = DateTime.Now.AddYears(-39),
                Salary = 5690.03,
                Role = Role.Acountant
            },
            new Employee()
            {
                Id = 4,
                FirstName = "Tomasz",
                LastName = "Kleaner",
                DateOfBirth = DateTime.Now.AddYears(-48),
                Salary = 2983.75,
                Role = Role.Service
            },
            new Employee()
            {
                Id = 5,
                FirstName = "Menczysław",
                LastName = "Cojarobietowski",
                DateOfBirth = DateTime.Now.AddYears(-23),
                Salary = 6502.29,
                Role =Role.CEO
            },
            new Employee()
            {
                Id = 6,
                FirstName = "Konrad",
                LastName = "Gaźnikow",
                DateOfBirth = DateTime.Now.AddYears(-17),
                Salary = 3549.07,
                Role = Role.Mechanic
            }
        };

        public void Update(Employee model)
        {
            var employee = GetById(model.Id);
            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.DateOfBirth = model.DateOfBirth;
            employee.Salary = model.Salary;
            employee.Role = model.Role;
            SaveToFile();
        }

        private static int IdCounter = 6;
        public List<Employee> GetAll()
        {
            string jasonFromFile = File.ReadAllText(@"employeeList.json");

            Employees = JsonSerializer.Deserialize<List<Employee>>(jasonFromFile);
            return Employees;
        }

        private int GetNextId()
        {
            IdCounter = IdCounter + 1;
            return IdCounter;
        }

        public void Delete(int id)
        {
            Employees.Remove(GetById(id));
            SaveToFile();
        }

        public Employee GetById(int id)
        {
            return Employees.FirstOrDefault(e => e.Id == id);
        }
        public void Create(Employee employee)
        {
            employee.Id = GetNextId();
            Employees.Add(employee);
            SaveToFile();
        }
        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(Employees);

            File.WriteAllText(@"C:\Users\Łukasz\Desktop\RepoWarsztat567\jcszr5-Majstry\Warsztat\Warsztat_v2\employeeList.json", json);
        }
        //private void DeleteFromFile()
        //{
        //    string jasonFromFile = File.ReadAllText(@"C:\Users\2021\source\repos\jcszr5-Majstry\Warsztat\Warsztat_v2\employeeList.json");
        //    Employees = JsonSerializer.Deserialize<List<Employee>>(jasonFromFile);
        //}
    }
}
