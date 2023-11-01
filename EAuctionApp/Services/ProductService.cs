
using EAuctionApp.Model;

namespace EAuctionApp.Services
{
    public class ProductService : IProductService
    {
        private  AuctionContext _auctionContext;

        public ProductService(AuctionContext auctionContext)
        {
            _auctionContext = auctionContext;
        }


        public  List<ProductDetails> GetAllProducts()
        {
            return _auctionContext.Set<ProductDetails>().ToList();

        }

    }
}
