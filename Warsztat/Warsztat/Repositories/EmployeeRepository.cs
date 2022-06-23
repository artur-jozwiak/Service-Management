using System.Text.Json;

namespace Warsztat
{
    public class EmployeeRepository
    {
        public void SaveMechanicToFile(List<Mechanic> mechanics)// zapis listy do pliku
        {
            string json = JsonSerializer.Serialize(mechanics);
            File.WriteAllText(@"..\..\..\MechanicList.json", json);
        }

        public List<Mechanic> ReadMechanicFromFile()// odczyt listy z pliku
        {
            string jsonFromFile = File.ReadAllText(@"..\..\..\MechanicList.json");
            List<Mechanic> mechanicFromFile = JsonSerializer.Deserialize<List<Mechanic>>(jsonFromFile);

            return mechanicFromFile;
        }


    }

}
