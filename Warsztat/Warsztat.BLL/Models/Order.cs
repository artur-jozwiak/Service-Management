using System.ComponentModel.DataAnnotations;
using Warsztat.BLL.Enums;
namespace Warsztat.BLL.Models
{
    public class Order
    {

        [Key]
        public int Id { get; set; }
        //[Display(Name = "Order IDN")]
        public string OrderNumber { get; set; }

        [Display(Name = "Start")]
        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        public Status Status { get; set; }
       

        public  string? Fault { get; set; }
        public string Client { get; set; }

        [Display(Name = "Reg Number")]
        public string RegistrationNumber { get; set; }

        public string Car { get; set; }
        public string Mechanic { get; set; }

        public string Part { get; set; }
        //public  Part[] Part { get; set; }
        //public List<Part> Part { get; set; }

        [Display(Name = "Pcs")]

        public System.Nullable<int> PartPcs { get; set; }
        
        public float Price { get; set; }
       
    }

}
//public List<Order> orders = new List<Order>
//        {
//            new Order()
//            {
//                Id=1,
//                OrderNumber="123",
//                StartTime=DateTime.Now,
//                Status= "Waiting",
//                Fault="COś",
//                Client = "Adam Beczka",
//                RegistrationNumber= "LLB36210",
//                Car=null,
//                Mechanic = null,
//                Part = null,
//                PartPcs = 1,
//                Price=50,
//            },
//        };
//public List<Order> GetAll()
//{
//    //List<Order> orders = _orderRepository.ReadFromFile();
//    return orders;
//}

//public Order GetById(int id)
//{
//    return orders.FirstOrDefault(o => o.Id == id);
//}


//public void Create(Order order)
//{

//    orders = GetAll();
//    order.Id = GetNextId();

//    orders.Add(order);
//    _orderRepository.SaveToFile(orders);
//}
//public int GetNextId()
//{
//    orderId += 1;
//    return orderId;
//}