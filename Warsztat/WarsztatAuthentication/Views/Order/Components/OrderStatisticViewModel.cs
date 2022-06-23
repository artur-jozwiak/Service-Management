using Warsztat.BLL.Services;
using Warsztat.BLL.Enums;

namespace Warsztat_v2.Views.Order.Components
{
    public class OrderStatisticViewModel
    {
        public int WaitingOrders { get; set; }
        public int InVerivicationOrders { get; set; }
        public int InProgressOrders { get; set; }
        public int FinishedOrders { get; set; }
        public int CacncelledOrders { get; set; }
    }
}
