namespace Lab4.Repositories
{
    // The <T> makes this repository generic, meaning it can work with any class (Student, Department, etc.)
    public interface IGenericRepo<T> where T : class
    {
        // Using IQueryable for GetAll to allow chaining Includes and Pagination in the controller
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
