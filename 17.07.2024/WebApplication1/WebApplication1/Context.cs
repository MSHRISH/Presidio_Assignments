using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace WebApplication1
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
