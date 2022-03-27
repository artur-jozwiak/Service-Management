using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Warsztat
{
    public class Order1
    {
        public string Status1 { get; set; }
        public string Fault1 { get; set; }
        public string BrandOfCar1 { get; set; }
        public string ModelOfCar1 { get; set; }
        public int ProductionYearOfCar1 { get; set; }
      public Mechanic Mechanic1 { get; set; }

        public Order1(string status, string fault, Mechanic mechanic, int productionYearOfCar, string brandOfCar, string modelOfCar)
        {
            Status1 = status;
            Fault1 = fault;
            BrandOfCar1 = brandOfCar;
            ModelOfCar1 = modelOfCar;
            ProductionYearOfCar1 = productionYearOfCar;
            Mechanic1 = mechanic;

        }
    }
}
