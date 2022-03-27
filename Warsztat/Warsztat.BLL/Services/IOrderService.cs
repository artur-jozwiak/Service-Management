using Warsztat.BLL.Models;

namespace Warsztat.BLL.Services
{
    public interface IOrderService
    {
        string OrderNumberGenerator(Order order/*string registrationNumber, string startTime, string id*/);
        List<Order> GetAll();
        Order GetById(int id);
        void Create(Order order);
        int GetNextId();
        void Update(Order model);
        void Delete(int id);
        float GetCostOfOrder(Order order);
    }
}