using System.Text.Json;

namespace Warsztat
{
    public class PartRepository
    {
        //public Part AddPartOf()// PRZYPISANIE CZESCI
        //{
        //    List<Parts> AddParts = ReadPartFromFile();
        //    ReadPartFromFile();
        //    PrintAllPart(AddParts);
        //    Parts addPart = addParts[int.Parse(Console.ReadLine()) - 1];
        //    return addPart;
        //}
        
        

        public void SavePartToFile(List<Part> parts) // zapis listy do pliku
        {
            string json = JsonSerializer.Serialize(parts);
            File.WriteAllText(@"..\..\..\PartList.json", json);
        }

        public List<Part> ReadPartFromFile()// odczyt listy z pliku
        {
            string jsonFromFile = File.ReadAllText(@"..\..\..\PartList.json");
            List<Part> PartFromFile = JsonSerializer.Deserialize<List<Part>>(jsonFromFile);

            return PartFromFile;
        }
    }
}
