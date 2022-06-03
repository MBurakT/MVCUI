using Microsoft.EntityFrameworkCore;
using Mvc.Models;

namespace Mvc.Data
{
    public class EtradeContext : DbContext
    {
        public EtradeContext(DbContextOptions<EtradeContext> options): base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

    }
}
