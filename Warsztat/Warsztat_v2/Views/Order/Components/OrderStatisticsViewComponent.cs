using Microsoft.AspNetCore.Mvc;
using Warsztat.BLL.Services;
using Warsztat.BLL.Models;
using Warsztat.BLL.Enums;

namespace Warsztat_v2.Views.Order.Components
{
    public class OrderStatisticsViewComponent : ViewComponent
    {
        private readonly IOrderService _orderService;

        public OrderStatisticsViewComponent(IOrderService orderService)
        {
 
            _orderService= orderService;    
        }

        public IViewComponentResult Invoke( )
        {
            var viewModel = new OrderStatisticViewModel
            {
                WaitingOrders = _orderService.GetAll().Count(s => s.Status == Status.Waiting),
                InProgressOrders = _orderService.GetAll().Count(s => s.Status == Status.InProgress),
                InVerivicationOrders = _orderService.GetAll().Count(s => s.Status == Status.Verification),
                FinishedOrders = _orderService.GetAll().Count(s => s.Status == Status.Finished),
                CacncelledOrders = _orderService.GetAll().Count(s => s.Status == Status.Cancelled),
                Total = _orderService.GetAll().Count(),
            };
         
            return View(viewModel);
        }
    }
}
