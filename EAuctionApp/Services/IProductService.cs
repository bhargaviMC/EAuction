using EAuctionApp.Model;

namespace EAuctionApp.Services
{
    public interface IProductService
    {
        List<ProductDetails> GetAllProducts();
    }
}
