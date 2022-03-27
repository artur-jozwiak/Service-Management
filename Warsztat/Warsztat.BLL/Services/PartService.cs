using System.Text.Json;
using Warsztat.BLL.Models;

namespace Warsztat.BLL.Services
{
    public class PartService : IPartService
    {
        private static List<Part> Parts = new List<Part>
        {
            new Part()
            {
                Id = 1,
                PartName = "Brake pads",
                PartPrice = 300,
                Quantity = 1,

            },
             new Part()
            {
                Id = 2,
                PartName = "Oil Engine",
                PartPrice = 200,
                Quantity = 2,

            },
              new Part()
            {
                Id = 3,
                PartName = "Filter Air",
                PartPrice = 50,
                Quantity = 1,

            },
               new Part()
            {
                Id = 4,
                PartName = "Filter Petrol",
                PartPrice = 40,
                Quantity = 5,

            },
            new Part()
            {
                Id = 5,
                PartName = "Brake Discs",
                PartPrice = 500,
                Quantity = 6,

            },
            new Part()
            {
                Id = 6,
                PartName = "AC",
                PartPrice = 1000,
                Quantity = 8,

            },
             new Part()
            {
                Id = 7,
                PartName = "Wheel",
                PartPrice = 350,
                Quantity = 1,

            }
        };

        public void Update(Part model)
        {
            var part = GetById(model.Id);
            part.PartName = model.PartName;
            part.PartPrice = model.PartPrice;
            part.Quantity = model.Quantity;
            SaveToFile();

        }

        private static int IdCounter = 7;
        public List<Part> GetAll()
        {
            string jasonFromFile = File.ReadAllText(@"PartList.json");
            Parts = JsonSerializer.Deserialize<List<Part>>(jasonFromFile);
            return Parts;
        }


        public void Delete(int id)
        {
            Parts.Remove(GetById(id));
            SaveToFile();
        }

        public Part GetById(int id)
        {
            return Parts.FirstOrDefault(e => e.Id == id);
        }
        public void Create(Part part)
        {
            part.Id = GetNextId();
            Parts.Add(part);
            SaveToFile();
        }
        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(Parts);

            File.WriteAllText(@"..\..\..\PartList.json", json);
        }

        public int GetNextId()
        {
            IdCounter = IdCounter + 1;
            return IdCounter;
        }

    }
}
