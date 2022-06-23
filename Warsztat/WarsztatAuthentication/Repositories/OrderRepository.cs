using Warsztat.BLL.Models;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public ServiceContext Context { get; set; }
        public List<Order> OrderList { get; set; }

        public OrderRepository(ServiceContext context)
        {
            Context = context;
            OrderList = context.Orders.ToList();
        }
        /*
        public List<Order> ReadFromDB(ServiceContext context)
        {
            var orders = context.Orders.ToList();
            return orders;
        }
        */
        public List<Order> GetAll()
        {
            return Context.Orders.ToList();
        }

        public void Add(Order order)
        {
            //order.Price = GetCostOfOrder(order);
            Context.Orders.Add(order);
            Context.SaveChanges();
        }

        public void Update(Order model)
        {
            var order = GetById(model.Id);
            order.RegistrationNumber = model.RegistrationNumber;
            order.StartTime = model.StartTime;
            order.PartPcs = model.PartPcs;
            order.Status = model.Status;
            order.Car = model.Car;
            order.Client = model.Client;
            order.Price = GetCostOfOrder(model);
            order.Part = model.Part;
            order.Fault = model.Fault;
            order.Mechanic = model.Mechanic;
            Context.SaveChanges();

        }
        public void Delete(int id)
        {
            var order = GetById(id);
            Context.Orders.Remove(order);
            Context.SaveChanges();
        }

        public Order GetById(int id)
        {
            return OrderList.FirstOrDefault(o => o.Id == id);
        }

        public float GetCostOfOrder(Order order)
        {
            float price = 0;
            var part = OrderList.FirstOrDefault(p => p.Part == order.Part);
            order.Price = (float)(order.PartPcs * part.Price);
            price = order.Price;
            return price;
        }

        public string OrderNumberGenerator(Order order)
        {
            return order.RegistrationNumber + "/" + order.StartTime.ToString("yyyy") + "/" + order.Id.ToString();
        }
    }
}



