namespace Lab1.Services
{
    public interface IService<T> where T : class
    {
        // Method to retrieve all items of type T
        List<T> GetAll();
        // Method to retrieve a single item of type T by its ID
        T GetById(int id);
        // Add a new item
        void Add(T item);

        // Update an existing item
        void Update(int id, T item);

        // Delete an item
        void Delete(int id);
    }
}
