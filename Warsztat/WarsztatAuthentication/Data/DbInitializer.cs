using Warsztat.BLL.Models;

namespace Warsztat_v2.Data
{
    public class DbInitializer
    {

        public static void Initialize(ServiceContext context)
        {

            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Orders.Any())
            {
                return;   // DB has been seeded
            }

            var cars = new Car[]
            {
            new Car
            {
                CarModel = "A6",
                CarMark = "Audi",
                YearProduction = 2017
            },
            new Car
            {
                CarModel = "Laguna",
                CarMark = "Renault",
                YearProduction = 2008
            },
            new Car
            {
                CarModel= "407",
                CarMark= "Peugeot",
                YearProduction= 2004
            },
            new Car
            {
                CarModel = "Corolla",
                CarMark = "Toyota",
                YearProduction = 2014
            },
            new Car
            {
                CarModel = "C5",
                CarMark = "Citroen",
                YearProduction = 2020
            },
            new Car
            {
                CarModel = "E60",
                CarMark = "BMW",
                YearProduction = 2006
            },
            new Car
            {
                CarModel = "A8",
                CarMark = "Audi",
                YearProduction = 2013
            }
            };

            var employees = new Employee[]
            {
            new Employee
            {
                FirstName = "Kuba",
                LastName = "Powiatowy",
                DateOfBirth = DateTime.Parse("1993-02-23"),
                Salary = 3245,
                Role = Warsztat.BLL.Enums.Role.Service
            },
            new Employee
            {
                FirstName = "Jaroslaw",
                LastName = "Polskezbawsky",
                DateOfBirth = DateTime.Parse("1956-02-23"),
                Salary = 168998.99,
                Role = Warsztat.BLL.Enums.Role.Manager
            },
            new Employee
            {
                FirstName = "Tomasz",
                LastName = "Kleaner",
                DateOfBirth = DateTime.Parse("1974-02-23"),
                Salary = 2983.75,
                Role = Warsztat.BLL.Enums.Role.Mechanic
            },
            new Employee
            {
                FirstName = "Konrad",
                LastName = "Gaźnikow",
                DateOfBirth = DateTime.Parse("2005-02-23"),
                Salary = 3549.07,
                Role = Warsztat.BLL.Enums.Role.CEO
            },
            new Employee
            {
                FirstName = "Kubaa",
                LastName = "Powiatowy",
                DateOfBirth = DateTime.Parse("1993-02-23"),
                Salary = 3245,
                Role = Warsztat.BLL.Enums.Role.Mechanic
            }
            };

            var parts = new Part[]
            {
            new Part
            {
                PartName = "Filter Air",
                PartPrice = 57,
                Quantity = 1
            },
            new Part
            {
                PartName = "Filter Petrol",
                PartPrice = 40,
                Quantity = 5
            },
            new Part
            {
                PartName = "Brake Discs",
                PartPrice = 500,
                Quantity = 6
            },
            new Part
            {
                PartName = "AC",
                PartPrice = 1000,
                Quantity = 8
            },
            new Part
            {
                PartName = "Wheel",
                PartPrice = 350,
                Quantity =  1
            },
            new Part
            {
                PartName = "Brake pads",
                PartPrice = 367,
                Quantity = 1
            },
            new Part
            {
                PartName = "Oil Engine",
                PartPrice =  201,
                Quantity = 2
            }

            };

            var orders = new Order[]
{
                new Order
                    {
                        OrderNumber = "HPD02378/2022/2",
                        StartTime = DateTime.Parse("2022-03-11"),
                        Status = Warsztat.BLL.Enums.Status.Waiting,
                        Fault = "Break system fault",
                        Client = "Bogdan Frankowski",
                        RegistrationNumber = "HPD02378",
                        Car = "Laguna",
                        Mechanic = "Tomasz",
                        Part = "Brake pads",
                        PartPcs = 0,
                        Price = 0
                    },
                new Order
                {
                        OrderNumber = "HPD32819/2022/3",
                        StartTime = DateTime.Parse("2022-03-11"),
                        Status = Warsztat.BLL.Enums.Status.InProgress,
                        Fault = "Engine fault",
                        Client = "Zbigniew Stonoga",
                        RegistrationNumber = "HPD32819",
                        Car = "C5",
                        Mechanic = "Konrad",
                        Part = "Oil Engine",
                        PartPcs = 5,
                        Price = 370
                },
                new Order
                {
                        OrderNumber = "LCH32145/2022/4",
                        StartTime = DateTime.Parse("2022-03-02"),
                        Status = Warsztat.BLL.Enums.Status.Cancelled,
                        Fault = "Wheels change",
                        Client = "Iwona Krajewska",
                        RegistrationNumber = "LCH32145",
                        Car = "Corolla",
                        Mechanic = "Kuba",
                        Part = "Wheel",
                        PartPcs = 4,
                        Price = 3060
                },
};

            foreach (Car car in cars)
            {
                context.Cars.Add(car);
            }

            foreach (Employee employee in employees)
            {
                context.Employees.Add(employee);
            }

            foreach (Part part in parts)
            {
                context.Parts.Add(part);
            }

            foreach (Order order in orders)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}
