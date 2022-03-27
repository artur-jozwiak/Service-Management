using Warsztat.BLL.Models;
using Warsztat.BLL.Services;

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


            var orders = new Order[]
            {
            new Order{OrderNumber="Carson",},

            };
            foreach (Order order  in orders)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();



            var employees = new Employee[]
            {
            new Employee{FirstName=""},

            };
            foreach (Employee e  in employees)
            {
                context.Employees.Add(e);
            }
            context.SaveChanges();

            var parts = new Part[]
            {
            new Part{PartName="sdfg"},

            };
            foreach (Part p in parts)
            {
                context.Parts.Add(p);
            }
            context.SaveChanges();

            var cars = new Car[]
            {
            new Car{CarMark="sdfg"},

            };
            foreach (Car c in cars)
            {
                context.Cars.Add(c);
            }
            context.SaveChanges();
        }
    }
}
