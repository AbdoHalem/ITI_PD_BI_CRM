namespace Lab1.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }

        // Foreign key to link product to its category
        public int CatID { get; set; }
    }
}
