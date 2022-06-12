using Microsoft.EntityFrameworkCore;


namespace Mc2.CrudTest.Presentation.Server.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
