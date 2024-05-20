using EmployeeRequestTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace EmployeeRequestTrackerAPI.Contexts
{
    public class RequestTrackerContext:DbContext
    {
        public RequestTrackerContext(DbContextOptions options):base(options) { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Authentication> Authentications { get; set; }
        public DbSet<Request> Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
    }
}
