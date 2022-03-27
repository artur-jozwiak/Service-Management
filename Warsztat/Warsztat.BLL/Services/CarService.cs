using System.Text.Json;
using Warsztat.BLL.Models;

namespace Warsztat.BLL.Services
{
    public class CarService /*: ICarService*/
    {
        public List<Car> Carrs = new List<Car>
        {
            new Car()
            {
                Id = 1,
                CarMark = "Audi",
                CarModel = "A6",
                YearProduction1 = 2017,

            },
             new Car()
            {
                Id = 2,
                CarMark = "Renault",
                CarModel = "Laguna",
                YearProduction1 = 2008,

            },
              new Car()
            {
                Id = 3,
                CarMark = "Peugeot",
                CarModel = "407",
                YearProduction1 = 2004,

            },
               new Car()
            {
                Id = 4,
                CarMark = "Toyota",
                CarModel = "Corolla",
                YearProduction1 = 2014,

            },
            new Car()
            {
                Id = 5,
                CarMark = "Jeep",
                CarModel = "Wrangler",
                YearProduction1 = 2012,

            },
            new Car()
            {
                Id = 6,
                CarMark = "Citroen",
                CarModel = "C5",
                YearProduction1 = 2020,

            },
             new Car()
            {
                Id = 7,
                CarMark = "BMW",
                CarModel = "E60",
                YearProduction1 = 2006,

            }
        };

        public void Update(Car model)
        {
            var carr = GetById(model.Id);
            carr.CarModel = model.CarModel;
            carr.CarMark = model.CarMark;
            carr.YearProduction1 = model.YearProduction1;
            SaveToFile();

        }


        private static int IdCounter = 7;
        public List<Car> GetAll()
        {
            // string jasonFromFile = File.ReadAllText(@"C:\Users\Łukasz\Desktop\RepoWarsztat567\jcszr5-Majstry\Warsztat\Warsztat_v2\CarrList.json");
            //Carrs = JsonSerializer.Deserialize<List<Carr>>(jasonFromFile);
            return Carrs;
        }


        public void Delete(int id)
        {
            Carrs.Remove(GetById(id));
            SaveToFile();
        }

        public Car GetById(int id)
        {
            return Carrs.FirstOrDefault(e => e.Id == id);
        }
        public void Create(Car carr)
        {
            carr.Id = GetNextId();
            Carrs.Add(carr);
            SaveToFile();
        }
        private void SaveToFile()
        {
            string json = JsonSerializer.Serialize(Carrs);

            File.WriteAllText(@"C:\Users\Łukasz\Desktop\RepoWarsztat567\jcszr5-Majstry\Warsztat\Warsztat_v2\CarrList.json", json);
        }

        private int GetNextId()
        {
            IdCounter = IdCounter + 1;
            return IdCounter;
        }

    }
}
