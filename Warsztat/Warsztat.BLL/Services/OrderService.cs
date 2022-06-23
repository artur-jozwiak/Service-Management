using Warsztat.BLL.Models;
using Warsztat.BLL.Services.Interfaces;

namespace Warsztat.BLL.Services
{
    public class OrderService : IOrderService
    {

        public float GetCostOfOrder(Order order)
        {
            float price = 0;
            //var part = OrderList.FirstOrDefault(p => p.Part == order.Part);
            //order.Price = (float)(order.PartPcs * part.Price);
            price = order.Price;
            return price;
        }

        //public string OrderNumberGenerator(Order order)
        //{
        //    return order.RegistrationNumber + "/" + order.StartTime.ToString("yyyy") + "/" + order.Id.ToString();
        //}

        public  string OrderNumberGenerator(string registrationNumber,DateTime startTime, int id)
        {
            return  registrationNumber + "/" + startTime.ToString("yyyy") + "/" + id.ToString();
        }

    }
}
