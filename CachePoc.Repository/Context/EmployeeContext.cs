using CachePoc.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace CachePoc.DAL.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
