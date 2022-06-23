using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Enums;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Views.Order.Components
{
    public class OrderStatisticsViewComponent : ViewComponent
    {
        private readonly IOrderRepository _orderRepository;

        public OrderStatisticsViewComponent(IOrderRepository orderRepository)
        {

            _orderRepository = orderRepository;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new OrderStatisticViewModel
            {
                WaitingOrders = _orderRepository.GetAll().Count(s => s.Status == Status.Waiting),
                InProgressOrders = _orderRepository.GetAll().Count(s => s.Status == Status.InProgress),
                InVerivicationOrders = _orderRepository.GetAll().Count(s => s.Status == Status.Verification),
                FinishedOrders = _orderRepository.GetAll().Count(s => s.Status == Status.Finished),
                CacncelledOrders = _orderRepository.GetAll().Count(s => s.Status == Status.Cancelled),
            };

            return View(viewModel);
        }
    }
}
