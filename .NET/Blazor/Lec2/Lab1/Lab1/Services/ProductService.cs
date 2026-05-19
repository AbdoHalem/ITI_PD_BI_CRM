using Lab1.Models;

namespace Lab1.Services
{
    public class ProductService : IProductService
    {
        // Static list to simulate a database
        private static List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Laptop", Price = 15000, CatID = 1, Image = "laptop.jpg" },
            new Product { Id = 2, Name = "Mobile", Price = 8000, CatID = 1, Image = "mobile.jpg" },
            new Product { Id = 3, Name = "T-Shirt", Price = 250, CatID = 2, Image = "t-shirt.jpg" },
            new Product { Id = 4, Name = "Jeans", Price = 400, CatID = 2, Image = "jeans.jpg" }
        };

        public List<Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product item)
        {
            item.Id = _products.Max(p => p.Id) + 1;
            _products.Add(item);
        }

        public void Update(int id, Product item)
        {
            var existing = GetById(id);
            if (existing != null)
            {
                existing.Name = item.Name;
                existing.Price = item.Price;
                existing.CatID = item.CatID;
                existing.Image = item.Image;
            }
        }

        public void Delete(int id)
        {
            var item = GetById(id);
            if (item != null)
            {
                _products.Remove(item);
            }
        }

        // The specific method from IProductService
        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CatID == categoryId).ToList();
        }
    }
}
