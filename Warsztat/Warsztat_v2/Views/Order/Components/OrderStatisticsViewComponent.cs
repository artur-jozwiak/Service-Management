using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Enums;
using Warsztat_v2.Data;
using Warsztat_v2.Repositories.Interfaces;

namespace Warsztat_v2.Views.Order.Components
{
    public class OrderStatisticsViewComponent : ViewComponent
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ServiceContext _serviceContext;

        public OrderStatisticsViewComponent(IOrderRepository orderRepository, ServiceContext serviceContext)
        {

            _orderRepository = orderRepository;
            _serviceContext = serviceContext;
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
                Total = _orderRepository.GetAll().Count(),
                //WaitingOrders = _serviceContext.Orders.Count(s => s.Status == Status.Waiting),
                //InProgressOrders = _serviceContext.Orders.Count(s => s.Status == Status.InProgress),
                //InVerivicationOrders = _serviceContext.Orders.Count(s => s.Status == Status.Verification),
                //FinishedOrders = _serviceContext.Orders.Count(s => s.Status == Status.Finished),
                //CacncelledOrders = _serviceContext.Orders.Count(s => s.Status == Status.Cancelled),
            };

            return View(viewModel);
        }
    }
}
