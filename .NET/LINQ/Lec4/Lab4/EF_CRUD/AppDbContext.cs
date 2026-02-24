using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace EF_CRUD
{
    public class AppDbContext : DbContext
    {
        // This DbSet will become the "Employees" table in SQL Server
        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configure the connection string
            optionsBuilder.UseSqlServer("Data Source=.\\SQLEXPRESS; Initial Catalog=EF_Lab; Integrated Security=True; TrustServerCertificate=True;");
        }
    }
}
