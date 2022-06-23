namespace Warsztat.Objects
{
    internal class Service : Employee
    {


        public Service(string firstName, string lastName, int age, double salary) : base(firstName, lastName, age, salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }


    }
}

