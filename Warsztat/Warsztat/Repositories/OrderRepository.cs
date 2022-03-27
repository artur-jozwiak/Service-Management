using System.Text.Json;

namespace Warsztat
{
    public class OrderRepository
    {        
        public void SaveToFile(List<Order> orders)
        {
            string json = JsonSerializer.Serialize(orders);
            File.WriteAllText(@"..\..\..\OrderList.json", json);
        }

        public List<Order> ReadFromFile()
        {
            string jsonFromFile = File.ReadAllText(@"..\..\..\OrderList.json");
            List<Order> orderFromFile = JsonSerializer.Deserialize<List<Order>>(jsonFromFile);

            return orderFromFile;   
        }
    }
}


