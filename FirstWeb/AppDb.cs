using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;

namespace FirstWeb
{
    public class AppDb : DbContext
    {
        private readonly DbContextOptions _options;

        public AppDb(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<Customer> Customers { get; set; }
    }
}