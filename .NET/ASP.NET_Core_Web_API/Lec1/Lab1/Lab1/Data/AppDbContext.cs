using Lab1.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab1.Data
{
    public class AppDbContext : DbContext
    {
        // Pass the configuration options to the base DbContext class
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Represents the Courses table in the database
        public DbSet<Course> Courses { get; set; }
    }
}
