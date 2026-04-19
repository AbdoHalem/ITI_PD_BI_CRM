using Lab4.Models;

namespace Lab4.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITIContext _context;

        public IGenericRepo<Student> Students { get; private set; }

        // Constructor injects the DbContext and initializes repositories
        public UnitOfWork(ITIContext context)
        {
            _context = context;
            Students = new GenericRepo<Student>(_context);
        }

        // Call SaveChanges on the shared DbContext to persist all changes across repositories
        public int SaveTransaction()
        {
            return _context.SaveChanges();
        }

        // Clean up the DbContext when the UnitOfWork is disposed
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
