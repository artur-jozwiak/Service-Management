using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Warsztat
{
    public abstract class Employee1
    {
        public string FirstName1 { get; set; }
        public string LastName1 { get; set; } 
        public int Age1 { get; set; }
        public double Salary1 { get; set; }

        
        
        public Employee1(string firstName, string lastName, int age, double salary)
        {
            FirstName1 = firstName;
            LastName1 = lastName;
            Age1 = age;
            Salary1 = salary;
            
        }
        //public abstract void AddEmployees();
        //public abstract void DeleteEmploye();
        //public abstract void EditEmploye(Employee employee);
        public override string ToString()
        {
            return $"{FirstName1}, {LastName1}, {Age1},{Salary1}";
        }
        public virtual void ShowEmployee(Employee employee)
        {
            Console.WriteLine($"Name: {FirstName1} {LastName1}.\n" +
                $"Age: {Age1, -10}." +
                $"Salary: {Salary1}.");
        }


        //public virtual void AddEmployees(Employee employee)
        //{

        //    Console.WriteLine("Name:");
        //    string firstName = Console.ReadLine();
        //    Console.WriteLine("Surname:");
        //    string lastName = Console.ReadLine();
        //    Console.WriteLine("Age");
        //    bool loop = true;
        //    int age = 0, money = 0, myInt;
        //    while (loop)
        //    {
        //        bool myBool = int.TryParse(Console.ReadLine(), out myInt);
        //        if (myBool && myInt > 15 && myInt < 128)
        //        {
        //            age = myInt;
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Enter the correct data");
        //        }
        //    }
        //    while (loop)
        //    {
        //        bool myBool = int.TryParse(Console.ReadLine(), out myInt);
        //        if (myBool && myInt > -1)
        //        {
        //            money = myInt;
        //            break;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Enter the correct data");
        //        }
        //    }

        //    Employees.Add(new Mechanic(firstName, lastName, age, money));

        //}
    }
    

}
