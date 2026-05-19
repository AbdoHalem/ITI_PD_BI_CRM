using Lab1.Models;

namespace Lab1.Services
{
    public interface ICategoryService : IService<Category>
    {
        // Categories currently only need the basic CRUD operations, 
        // but we make this interface to apply the Dependency Inversion Principle properly.
    }
}
