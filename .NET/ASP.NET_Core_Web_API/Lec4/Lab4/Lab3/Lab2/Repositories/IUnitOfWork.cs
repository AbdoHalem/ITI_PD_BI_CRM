using Lab4.Models;

namespace Lab4.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        /**
         * Expose repositories for each entity type
         */
        // Property for the Student Repository
        IGenericRepo<Student> Students { get; }

        // Single method to save all changes across all repositories
        int SaveTransaction();

    }
}
