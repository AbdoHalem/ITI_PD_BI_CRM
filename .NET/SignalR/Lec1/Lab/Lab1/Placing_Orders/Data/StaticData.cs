using Placing_Orders.Models;

namespace Placing_Orders.Data
{
    public static class StaticData
    {
        public static List<Order> Orders = new List<Order>
        {
            new Order {Id = 1, Name = "Laura", ItemName = "Food4", Count = 3},
            new Order {Id = 2, Name = "Ben", ItemName = "Food2", Count = 1}
        };
    }
}
