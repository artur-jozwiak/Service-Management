using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class EmployeeService
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();

        public void AddMechanic()
        {

            Console.WriteLine("Enter data about ");
            Console.WriteLine("Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Surname:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Age");
            bool loop = true;
            int age = 0, money = 0, myInt;
            while (loop)
            {
                bool myBool = int.TryParse(Console.ReadLine(), out myInt);
                if (myBool && myInt > 15 && myInt < 128)
                {
                    age = myInt;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct data");
                }
            }
            Console.WriteLine("Salary:");
            while (loop)
            {
                bool myBool = int.TryParse(Console.ReadLine(), out myInt);
                if (myBool && myInt > -1)
                {
                    money = myInt;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct data");
                }
            }
            var mechanics = employeeRepository.ReadMechanicFromFile();
            mechanics.Add(new Mechanic(firstName, lastName, age, money));
            employeeRepository.SaveMechanicToFile(mechanics);
        }

        public object GetAll()
        {
            throw new NotImplementedException();
        }

        public void RemoveSelectedMechanic()
        {

            PrintAllMechanics();
            DecorateLine();
            Console.WriteLine($"Declare number of order for delete");
            DecorateLine();
            var mechanics = employeeRepository.ReadMechanicFromFile();

            int indexForRemove = int.Parse(Console.ReadLine());
            mechanics.RemoveAt(indexForRemove - 1);
            employeeRepository.SaveMechanicToFile(mechanics);
        }

        public Mechanic ChooseMechanic()// PRZYPISANIE MECHANIKA DO ZLECENIA
        {
            List<Mechanic> mechanics = employeeRepository.ReadMechanicFromFile();
            employeeRepository.ReadMechanicFromFile();
            PrintAllMechanics(/*mechanics*/);
            Mechanic mechanic = mechanics[int.Parse(Console.ReadLine()) - 1];
            return mechanic;
        }

        public void PrintAllMechanics()// WYŚWIETLANIE LISTY MECHANIKÓW
        {

            List<Mechanic> mechanics = employeeRepository.ReadMechanicFromFile();
            foreach (Mechanic mechanic in mechanics)
            {
                int index = mechanics.IndexOf(mechanic) + 1;
                Console.WriteLine($"{index}.{mechanic.FirstName} {mechanic.LastName}");
            }
        }

        public void EditDeclaredMechanic()
        {
            PrintAllMechanics();
            DecorateLine();
            Console.WriteLine($"Declare number of order to change");
            DecorateLine();
            var mechanics = employeeRepository.ReadMechanicFromFile();
            int indexToEdit = int.Parse(Console.ReadLine()) - 1;
            DecorateLine();
            Console.WriteLine("Enter data about ");
            Console.WriteLine("Name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Surname:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Age");
            bool loop = true;
            int age = 0, money = 0, myInt;
            while (loop)
            {
                bool myBool = int.TryParse(Console.ReadLine(), out myInt);
                if (myBool && myInt > 15 && myInt < 128)
                {
                    age = myInt;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct data");
                }
            }
            while (loop)
            {
                bool myBool = int.TryParse(Console.ReadLine(), out myInt);
                if (myBool && myInt > -1)
                {
                    money = myInt;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct data");
                }
            }
            mechanics[indexToEdit] = new Mechanic(firstName, lastName, age, money);
            employeeRepository.SaveMechanicToFile(mechanics);
        }

        public void DecorateLine()
        {
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
