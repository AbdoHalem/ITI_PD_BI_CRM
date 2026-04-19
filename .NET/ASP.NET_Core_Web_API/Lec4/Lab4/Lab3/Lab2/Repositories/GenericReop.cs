
using Lab4.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        private readonly ITIContext _context;
        private readonly DbSet<T> _dbSet;

        // Constructor injects the DbContext
        public GenericRepo(ITIContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();   
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            // Attach the entity and mark it as modified
            _dbSet.Update(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }  
    }
}
