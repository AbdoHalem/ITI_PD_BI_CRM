namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public int Price { get; set; }

    }
}
