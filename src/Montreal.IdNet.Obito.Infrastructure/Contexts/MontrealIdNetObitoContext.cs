using Microsoft.EntityFrameworkCore;
using Montreal.IdNet.Obito.Infrastructure.Mappings;

namespace Montreal.IdNet.Obito.Infrastructure.Contexts
{
    public class MontrealIdNetObitoContext : DbContext
    {
        public MontrealIdNetObitoContext(DbContextOptions<MontrealIdNetObitoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DemoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
