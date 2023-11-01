using EAuctionApp.Dto;
using EAuctionApp.Model;

namespace EAuctionApp.Repository
{
    public interface IBidDetailRepository
    {
        IQueryable<BidDetails> GetAllBidsForProduct(int productid);

        IQueryable<BidDetails> GetBidByID(int id);

        ResponseModel SaveBidDetail(AddBidDetailsDto bid);

        ResponseModel UpdateBid(int productId, string Email, int newamount);

        ProductWithBidsDto GetPrdocutAlongWithBids(int productId);
    }
}
