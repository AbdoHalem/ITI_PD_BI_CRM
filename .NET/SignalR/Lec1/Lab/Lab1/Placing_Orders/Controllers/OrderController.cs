using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Placing_Orders.Data;
using Placing_Orders.Hubs;
using Placing_Orders.Models;
using System.Diagnostics;

namespace Placing_Orders.Controllers
{
    public class OrderController : Controller
    {
        private readonly IHubContext<OrderHub> _hubContext;

        public OrderController(IHubContext<OrderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            return View(StaticData.Orders);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PlaceOrder(Order order)
        {
            order.Id = StaticData.Orders.Max(o => o.Id) + 1;
            StaticData.Orders.Add(order);

            await _hubContext.Clients.All.SendAsync("NewOrderReceived", order);

            return View();
        }
    }
}
