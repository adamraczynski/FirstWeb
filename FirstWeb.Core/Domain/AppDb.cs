using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstWeb.Core
{
    public class AppDb : DbContext
    {
        private readonly DbContextOptions _options;

        public AppDb(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public async Task<IEnumerable<Customer>> GetCustomersByNameAsync(string name = null) => await Customers
            .AsNoTracking()
            .Where(x => string.IsNullOrEmpty(name) || x.Name.StartsWith(name))
            .ToListAsync();

        public DbSet<Customer> Customers { get; set; }
    }
}