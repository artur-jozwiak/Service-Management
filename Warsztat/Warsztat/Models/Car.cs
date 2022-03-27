using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warsztat
{
    public class Car

    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }

        public Car(string brand, string model, int prodYear)
        {
            Brand = brand;
            Model = model;
            ProductionYear = prodYear;
        }

    }
}