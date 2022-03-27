using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Warsztat
{
    public class Mechanic1 : Employee1
    {
        public int repairCount;


        public Mechanic1(string firstName, string lastName, int age, double salary) : base(firstName, lastName, age, salary)
        {
            FirstName1 = firstName;
            LastName1 = lastName;
            Age1 = age;
            Salary1 = salary;

        }

        public override void ShowEmployee(Employee employee)
        {
            
            Console.WriteLine($"Name: {FirstName1} {LastName1}.\n" +
                $"Age: {Age1,10}.\n" +
                $"Salary: {Salary1, 8}.");
        }


    }
}
