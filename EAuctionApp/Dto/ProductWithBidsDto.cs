using EAuctionApp.Model;

namespace EAuctionApp.Dto
{
    public class ProductWithBidsDto
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        public List<BidDetails> bidDetails { get; set; }
    }
}
