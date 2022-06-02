using Microsoft.EntityFrameworkCore;

namespace Mvc.Data
{
    public class EtradeContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=ETRADE4;Integrated Security=True");
        }
    }
}
