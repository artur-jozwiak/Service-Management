using Warsztat.BLL.Services.Interfaces;

namespace Warsztat.BLL.Services
{
    public class PartService : IPartService
    {


        //public void Update(Part model)
        //{
        //    var part = GetById(model.Id);
        //    part.PartName = model.PartName;
        //    part.PartPrice = model.PartPrice;
        //    part.Quantity = model.Quantity;
        //    SaveToFile();

        //}

        //private static int IdCounter = 7;
        //public List<Part> GetAll()
        //{
        //    string jasonFromFile = File.ReadAllText(@"PartList.json");
        //    Parts = JsonSerializer.Deserialize<List<Part>>(jasonFromFile);
        //    return Parts;
        //}


        //public void Delete(int id)
        //{
        //    Parts.Remove(GetById(id));
        //    SaveToFile();
        //}

        //public Part GetById(int id)
        //{
        //    return Parts.FirstOrDefault(e => e.Id == id);
        //}
        //public void Create(Part part)
        //{
        //    part.Id = GetNextId();
        //    Parts.Add(part);
        //    SaveToFile();
        //}
        //public void SaveToFile()
        //{
        //    string json = JsonSerializer.Serialize(Parts);

        //    File.WriteAllText(@"..\..\..\PartList.json", json);
        //}

        //public int GetNextId()
        //{
        //    IdCounter = IdCounter + 1;
        //    return IdCounter;
        //}

    }
}
