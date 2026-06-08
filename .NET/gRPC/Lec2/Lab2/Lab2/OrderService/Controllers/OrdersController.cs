using Inventory.Service.Protos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderService.Models;
using Payment.Service.Protos;
using static Inventory.Service.Protos.Inventory;
using static Payment.Service.Protos.Payment;

namespace OrderService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly InventoryClient _inventoryService;
        private readonly PaymentClient _paymentService;

        public OrdersController(InventoryClient inventoryClient, PaymentClient paymentClient)
        {
            _inventoryService = inventoryClient;
            _paymentService = paymentClient;
        }

        [HttpPost]
        public async Task<ActionResult> BuyOrderAsync(Order order)
        {
            // 1. Check the quantity of each item in the order
            var inventoryResponse = await CheckQuantity(order);
            if (!inventoryResponse.IsSuccess)
            {
                return BadRequest(inventoryResponse.Message);
            }

            // 2. Calculate the order price
            foreach(var item in order.Items)
            {
                order.Price += item.Price;
            }
            var request = new PaymentRequest
            {
                OrderId = order.Id,
                OrderPrice = order.Price,
                UserId = order.UserId
            };

            // 3. Call the 'Payment Service' gRPC
            var response = await _paymentService.DeductBalanceAsync(request);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return Ok(new PaymentResponse { IsSuccess = true,
                Message = $"Order with id {order.Id} completed successfully."});
        }


        // ================ Helper Methods ================
        private async Task<InventoryResponse> CheckQuantity(Order order)
        {
            foreach(var item in order.Items)
            {
                var request = new InventoryRequest { ItemId = item.ItemId, Quantity = item.Quantity };
                
                // Calling the gRPC will throw an exception or return InventoryResponse
                var response = await _inventoryService.DeductQuantityAsync(request);
                if (!response.IsSuccess)
                {
                    return response;
                }
            }

            return new InventoryResponse { IsSuccess = true, Message = "All quantities are available" };
        }
    }
}
