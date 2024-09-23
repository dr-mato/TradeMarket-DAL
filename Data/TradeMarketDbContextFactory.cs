using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Data
{
    public class TradeMarketDbContextFactory : IDesignTimeDbContextFactory<TradeMarketDbContext>
    {
        public TradeMarketDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TradeMarketDbContext>();
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB; Database=TradeMarket; Trusted_Connection=True;");

            return new TradeMarketDbContext(optionsBuilder.Options);
        }
    }
}