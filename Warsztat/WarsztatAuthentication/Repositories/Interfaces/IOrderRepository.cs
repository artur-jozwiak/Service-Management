using Warsztat.BLL.Models;

namespace Warsztat_v2.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        void Add(Order order);
        void Delete(int id);
        void Update(Order order);
        public Order GetById(int id);
        public string OrderNumberGenerator(Order order);

    }
}