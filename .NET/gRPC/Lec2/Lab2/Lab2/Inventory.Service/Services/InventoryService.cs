using Grpc.Core;
using Inventory.Service.Models;
using Inventory.Service.Protos;
//using OrderService.Models;
using static Inventory.Service.Protos.Inventory;

namespace Inventory.Service.Services
{
    public class InventoryService(ILogger<InventoryService> logger) : InventoryBase
    {
        // Create a list of items with their available quantities
        private static List<Item> items = new List<Item>
        {
            new Item{ ItemId = 1, Quantity = 100 },
            new Item{ ItemId = 2, Quantity = 50 },
            new Item{ ItemId = 3, Quantity = 200 }
        };

        public override Task<InventoryResponse> DeductQuantity(InventoryRequest request, ServerCallContext context)
        {
            logger.LogInformation("The message is recieved with item id {ItemId} and quantity {Quantity}",
                request.ItemId, request.Quantity);

            // Find the item in the list based on the item id from the request
            var item = items.FirstOrDefault(i => i.ItemId == request.ItemId);
            if(item == null)
            {
                logger.LogWarning("Item with ID {ItemId} was not found.", request.ItemId);
                
                throw new RpcException(new Status(StatusCode.NotFound, $"Item with ID {request.ItemId} does not exist in inventory."));
            }

            // Check if we have enough quantity
            if(item.Quantity < request.Quantity)
            {
                logger.LogWarning("Insufficient stock for ItemId {ItemId}. Requested: {ReqQty}, Available: {AvailQty}",
                    item.ItemId, request.Quantity, item.Quantity);

                return Task.FromResult(new InventoryResponse
                {
                    IsSuccess = false,
                    Message = $"Failed: Inventory quantity of item ID {request.ItemId} is insufficient."
                });
            }

            // Sufficient stock
            item.Quantity -= request.Quantity;
            logger.LogInformation("Quantity deducted successfully.");

            return Task.FromResult(new InventoryResponse
            {
                IsSuccess = true,
                Message = $"Success: Deducted {request.Quantity} from item {request.ItemId}. Remaining stock: {item.Quantity}."
            });
        }
    }
}
