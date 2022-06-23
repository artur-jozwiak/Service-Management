using Warsztat.BLL.Models;

namespace Warsztat.BLL.Services.Interfaces
{
    public interface IOrderService
    {
        public float GetCostOfOrder(Order order);
        public string OrderNumberGenerator(string registrationNumber, DateTime startTime, int id);
    }
}