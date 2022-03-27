using System.Text.Json;
using Warsztat.BLL.Models;
using Warsztat.BLL.Repositories;

namespace Warsztat.BLL.Services
{
    public class OrderService : IOrderService
    {
        
        private IOrderRepository orderRepository;
        private IPartService partService;
        public Part part;
        public Order order;
        private List<Order> orders;

        public OrderService(IOrderRepository orderRepository, IPartService partService)
        {
            this.orderRepository = orderRepository;
            this.partService = partService;

        }

      
        public string OrderNumberGenerator(Order order/*string registrationNumber, string startTime, string id*/)
        {
          //  return registrationNumber + startTime + id;
            return order.RegistrationNumber + "/" + order.StartTime.ToString("yyyy") + "/" + order.Id.ToString();
 
        }
        private static int orderCounter;
        public List<Order> GetAll()
        {
            // orderRepository.SaveToFile(orders);// dodane żeby sformatować json
            List<Order> orders = orderRepository.ReadFromFile();
            return orders;
        }

        public Order GetById(int id)
        {
            orders = GetAll();

            return orders.FirstOrDefault(o => o.Id == id);
        }


        public void Create(Order order)
        {
            orders = GetAll(); 
            order.Id = GetNextId();
            order.StartTime = DateTime.Now;
            order.OrderNumber = OrderNumberGenerator(order/*order.RegistrationNumber, order.StartTime.ToString("yyyy"), order.Id.ToString()*/);
            order.Price = GetCostOfOrder(order);
            orders.Add(order);
            orderRepository.SaveToFile(orders);
        }
        public int GetNextId()
        {
            orders = GetAll();
            orderCounter = orders.Count() + 1;
            return orderCounter;
        }
        public void Update(Order model)
        {
            var order = GetById(model.Id);
            order.RegistrationNumber = model.RegistrationNumber;
            order.StartTime = model.StartTime;
            //   order.Id = model.Id;
            // order.OrderNumber = model.OrderNumber;
            order.PartPcs = model.PartPcs;
            order.Status = model.Status;
            order.Car = model.Car;
            order.Client = model.Client;
            //order.Price = model.Price;
            order.Price = GetCostOfOrder(model);
            order.Part = model.Part;
            order.Fault = model.Fault;
            order.Mechanic = model.Mechanic;
            orderRepository.SaveToFile(orders);

        }
        public void Delete(int id)
        {
            var order = GetById(id);
            orders.Remove(order);
            orderRepository.SaveToFile(orders);
        }

        public float GetCostOfOrder(Order order)
        {
            float price = 0;

            var part = partService.GetAll().FirstOrDefault(p => p.PartName == order.Part);
            order.Price = (float)order.PartPcs * part.PartPrice;
            price = (float)order.Price;
            return price;
        }

        //public int UpdatePartsQuantity()
        //{

        //}




    }
}
