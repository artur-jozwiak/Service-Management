namespace Warsztat
{
    public class Order
    {
        public string Status { get; set; }
        public string Fault { get; set; }
        public string BrandOfCar { get; set; }
        public string ModelOfCar { get; set; }
        public int ProductionYearOfCar { get; set; }
        //   public string MechanicName { get; set; }
        //   public string MechanicSurname { get; set; }
        public Mechanic Mechanic { get; set; }
        //public Car Car { get; set; }






        public Order(string status, string fault, Mechanic mechanic, int productionYearOfCar, string brandOfCar, string modelOfCar)
        {
            Status = status;
            Fault = fault;
            BrandOfCar = brandOfCar;
            ModelOfCar = modelOfCar;
            ProductionYearOfCar = productionYearOfCar;

            Mechanic = mechanic;
            // MechanicName = mechanicName;
            //MechanicSurname = mechanicSurname;
        }



        // public void PrintAllOrdersFromFile()// wyświetlenie listy z pliku
        // {
        //     string jsonFromFile = File.ReadAllText(@"D:\InfoShaREaCADEMY\Projekt\Projekt Warsztat\jcszr5-Majstry\Warsztat\Warsztat\path.json");
        //     List<Order> orderFromFile = JsonSerializer.Deserialize<List<Order>>(jsonFromFile);
        //    
        //     foreach (var order in orderFromFile)
        //     { 
        //         Number = orderFromFile.IndexOf(order) + 1;
        //         Console.WriteLine($"Order number      : {order.Number}");
        //         Console.WriteLine($"Status            : {order.Status}");
        //         Console.WriteLine($"Fault             : {order.Fault}");
        //         Console.WriteLine($"Car brand         : {order.BrandOfCar}");
        //         Console.WriteLine($"Model             : {order.ModelOfCar}");
        //         Console.WriteLine($"Year of production: {order.ProductionYearOfCar}");
        //         Console.WriteLine($"Mechanic :{order.MechanicName} {order.MechanicSurname}");
        //     }
        // }
    }
}
/*[
  {
    "Number": 1,
    "Status": "Waiting",
    "Fault": "No air in wheels",
    "BrandOfCar": "Fiat",
    "ModelOfCar": "126p",
    "ProductionYearOfCar": 1995,
    "MechanicName": "Rysiek",
    "MechanicSurname": "Niepsuj"
  },
  
    {
      "Number": 2,
      "Status": "Ended",
      "Fault": "No fuel",
      "BrandOfCar": "Fiat",
      "ModelOfCar": "Multipla",
      "ProductionYearOfCar": 1999,
      "MechanicName": "Kazimierz",
      "MechanicSurname": "Saleta"
    },
	 {
    "Number": 3,
    "Status": "In progres",
    "Fault": "Oil change",
    "BrandOfCar": "Mercedes",
    "ModelOfCar": "Vito",
    "ProductionYearOfCar": 2005,
    "MechanicName": "Rysiek",
    "MechanicSurname": "Niepsuj"
  }
  
]


*/

/*[

  {
    "Status": "Ended",
    "Fault": "No fuel",
    "Mechanic":
    {
      "FirstName": "Ryszard",
      "LastName": "Niepsuj",
      "Age": 55,
      "Salary": 50000
    }
    "Car":
    {
      "Brand": "Fiat",
      "Model": "Multipla",
      "ProductionYear": 1995
    }
  },
  {
    "Status": "Waiting",
    "Fault": "No air in wheels",
    "Mechanic":
    {
      "FirstName": "Piotr",
      "LastName": "Podgórny",
      "Age": 55,
      "Salary": 50000
    }
    "Car": 
    {
      "Brand": "Mercedes",
      "Model": "Vito",
      "ProductionYear": 2007
    }
  },
  {
    "Status": "In progress",
    "Fault": "Oil change",
    "Mechanic":
    {
      "FirstName": "Tomasz",
      "LastName": "Kowalski",
      "Age": 55,
      "Salary": 50000
    }
    "Car":
    {
      "Brand": "Fiat",
      "Model": "126p",
      "ProductionYear": 1995
    }
  }
]
*/