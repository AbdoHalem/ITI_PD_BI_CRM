using Lab1.Models;

namespace Lab1.Services
{
    public interface IProductService : IService<Product>
    {
        // Specific method for products: get products by category ID
        List<Product> GetProductsByCategoryId(int categoryId);
    }
}
