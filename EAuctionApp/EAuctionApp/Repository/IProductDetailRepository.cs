using EAuctionApp.Dto;
using EAuctionApp.Model;

namespace EAuctionApp.Repository
{
    public interface IProductDetailRepository
    {
        List<ProductDetails> GetAllProducts();
        IQueryable<ProductDetails> GetProductByID(int id);
        ResponseModel SaveProductDetail(SaveProductDetailsDto product);
        ResponseModel UpdateProductDetails(ProductDetails product);
        ResponseModel DeleteProduct(int productId);
        ProductWithBidsDto GetPrdocutAlongWithBids(int productId);
    }
}
