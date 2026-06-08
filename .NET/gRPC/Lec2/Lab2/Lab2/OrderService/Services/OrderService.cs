using Grpc.Core;
using Inventory.Service.Protos;
using OrderService.Models;
using Payment.Service.Protos;
using static Inventory.Service.Protos.Inventory;
using static OrderService.OrderService;
using static Payment.Service.Protos.Payment;

namespace OrderService.Services
{
    public class OrderService(ILogger<OrderService> logger,
        InventoryClient inventoryService,
        PaymentClient paymentService) : OrderServiceBase
    {
        public override async Task<OrderResponse> CreateOrder(OrderRequest orderRequest, ServerCallContext context)
        {
            logger.LogInformation($"Received a new order creation request for UserId: {orderRequest.UserId}");

            // 1. Check the quantity of each item in the order
            var inventoryResponse = await CheckQuantity(orderRequest);

            if (!inventoryResponse.IsSuccess)
            {
                logger.LogWarning(inventoryResponse.Message);
                return new OrderResponse
                {
                    IsSuccess = false,
                    Message = inventoryResponse.Message
                };
            }

            // 2. Calculate the order price
            foreach (var item in orderRequest.Items)
            {
                orderRequest.Price += item.Price;
            }
            var paymentRequest = new PaymentRequest
            {
                OrderId = orderRequest.OrderId,
                OrderPrice = orderRequest.Price,
                UserId = orderRequest.UserId
            };

            // 3. Call the 'Payment Service' gRPC
            var paymentResponse = await paymentService.DeductBalanceAsync(paymentRequest);
            if (!paymentResponse.IsSuccess)
            {
                logger.LogWarning(paymentResponse.Message);
                return new OrderResponse
                {
                    IsSuccess = false,
                    Message = paymentResponse.Message
                };
            }

            logger.LogInformation($"Order with id {orderRequest.OrderId} completed successfully.");
            return new OrderResponse
            {
                
                IsSuccess = true,
                Message = $"Order with id {orderRequest.OrderId} completed successfully."
            };
        }

        // ================ Helper Methods ================
        private async Task<InventoryResponse> CheckQuantity(OrderRequest order)
        {
            foreach (var item in order.Items)
            {
                var request = new InventoryRequest { ItemId = item.ItemId, Quantity = item.Quantity };

                // Calling the gRPC will throw an exception or return InventoryResponse
                var response = await inventoryService.DeductQuantityAsync(request);
                if (!response.IsSuccess)
                {
                    return response;
                }
            }

            return new InventoryResponse { IsSuccess = true, Message = "All quantities are available" };
        }
    }
}
