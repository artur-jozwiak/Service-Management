using Warsztat.BLL.Models;

namespace Warsztat.BLL.Repositories
{
    public interface IOrderRepository
    {
        public void SaveToFile(List<Order> orders);
        List<Order> ReadFromFile();
    }
}