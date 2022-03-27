using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class CarService
    {

        static public Car AddCar()
        {
            bool loop = true;
            string Brand, Model;
            Console.WriteLine($@"Enter brand of car");
            Brand = Console.ReadLine();
            Console.WriteLine($@"Enter model");
            Model = Console.ReadLine();
            Console.WriteLine($"Enter  production year:");
            int YearProduction = 0;
            bool myBool;
            while (loop)
            {
                myBool = int.TryParse(Console.ReadLine(), out YearProduction);
                if (myBool && YearProduction > 1952 && YearProduction < 2022)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter the correct details");
                }
            }
            return new Car(Brand, Model, YearProduction);
        }

    }
}
