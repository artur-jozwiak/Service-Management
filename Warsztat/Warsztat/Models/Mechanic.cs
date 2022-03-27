using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class Mechanic : Employee
    {


        public Mechanic(string firstName, string lastName, int age, double salary) : base(firstName, lastName, age, salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }


    }
}
