using EAuctionApp.Dto;
using EAuctionApp.Model;

namespace EAuctionApp.Repository
{
    public class BidDetailRepository: IBidDetailRepository
    {
        public AuctionContext _auctionContext;
        IProductDetailRepository _productService;

        public BidDetailRepository(AuctionContext auctionContext, IProductDetailRepository productService)
        {
            _auctionContext = auctionContext;
            _productService = productService;
        }

        public IQueryable<BidDetails> GetAllBidsForProduct(int productid)
        {
            IQueryable<BidDetails> bid;
            try
            {
                bid = _auctionContext.BidDetails.Where(x => x.ProductId == productid);


            }
            catch (Exception)
            {
                throw;
            }
            return bid;
        }

        public IQueryable<BidDetails> GetBidByID(int id)
        {
            IQueryable<BidDetails> bid;
            try
            {
                bid = _auctionContext.BidDetails.Where(x => x.BidId == id);


            }
            catch (Exception)
            {
                throw;
            }
            return bid;
        }

        public ResponseModel SaveBidDetail(AddBidDetailsDto bid)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                if (bid.Mobile.ToString().Length != 10)
                {
                    response.IsSuccess = false;
                    response.Messsage = "Mobile Number should be 10 digit";
                    return response;
                }

                IQueryable<ProductDetails> product = _productService.GetProductByID(bid.ProductId);


                if (product.Count() < 0)
                {
                    response.IsSuccess = false;
                    response.Messsage = "Product Not avaliable";
                    return response;
                }
                else
                {

                    var bidEndDate = product.Select(x => x.BidEndDate).FirstOrDefault();
                    if (bidEndDate < DateTime.Now)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "The Bid as Ended";
                        return response;
                    }

                    IQueryable<BidDetails> _temp = _auctionContext.BidDetails.Where(x => x.Email == bid.Email && x.ProductId == bid.ProductId);
                    if (_temp.Count() > 0)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "You have already submitted a Bid Please update your Bid";
                        return response;
                    }
                    else
                    {

                        _auctionContext.Add<BidDetails>(ConvertBidDtoToBidModel(bid));
                        response.Messsage = "Bid Added Successfully";
                        _auctionContext.SaveChanges();
                        response.IsSuccess = true;
                        return response;
                    }

                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messsage = "Unable to add the Bid" + ex.Message;
                return response;
            }
        }

        private BidDetails ConvertBidDtoToBidModel(AddBidDetailsDto detailsDto)
        {
            BidDetails bidDetails = new BidDetails();

            bidDetails.ProductId = detailsDto.ProductId;
            bidDetails.BidAmount = detailsDto.BidAmount;
            bidDetails.Email = detailsDto.Email;
            bidDetails.FirstName = detailsDto.FirstName;
            bidDetails.LastName = detailsDto.LastName;
            bidDetails.Address = detailsDto.Address;
            bidDetails.City = detailsDto.City;
            bidDetails.State = detailsDto.State;
            bidDetails.ZipCode = detailsDto.ZipCode;
            bidDetails.Mobile = detailsDto.Mobile;

            return bidDetails;
        }
        public ResponseModel UpdateBid(int productId, string Email, int newamount)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                IQueryable<ProductDetails> product = _productService.GetProductByID(productId);


                if (product.Count() < 0)
                {
                    response.IsSuccess = false;
                    response.Messsage = "Product Not avaliable";
                    return response;
                }
                else
                {

                    var bidEndDate = product.Select(x => x.BidEndDate).FirstOrDefault();
                    if (bidEndDate < DateTime.Now)
                    {
                        response.IsSuccess = false;
                        response.Messsage = "The Bid as Ended";
                        return response;
                    }

                   IQueryable<BidDetails> _temp = _auctionContext.BidDetails.Where(x => x.Email == Email && x.ProductId == productId);
                    
                    if (_temp.Count() > 0)
                    {

                        _temp.First().BidAmount = newamount;

                        _auctionContext.Update<BidDetails>(_temp.First());
                        _auctionContext.SaveChanges();
                        response.IsSuccess = true;
                        response.Messsage = "Bid Amount Updated";
                        return response;
                    }
                    else
                    { 
                        response.IsSuccess = false;
                        response.Messsage = "You dont have existing bit please Add a Bid";
                        return response;
                    }
                }

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messsage = "Unable to add the Bid" + ex.Message;
                return response;
            }
            

        }
    }
}
