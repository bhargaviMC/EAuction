using Microsoft.EntityFrameworkCore;

namespace EAuctionApp.Model
{
    public class AuctionContext : DbContext
    {
        public AuctionContext(DbContextOptions<AuctionContext> options):base(options)
        {
              
        }

        public DbSet<ProductDetails>  ProductDetails { get; set; }
        public DbSet<BidDetails> BidDetails { get; set; }
    }
}
