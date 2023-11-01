using EAuctionApp.Authentication;
using EAuctionApp.Dto;
using EAuctionApp.Model;
using EAuctionApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAuctionApp.Controllers
{
    [Authorize(Roles = UserRoles.Buyer)]
    [Route("e-auction/api/v1/buyer")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        IBidDetailRepository _bidDetailRepository;

        public BuyerController(IBidDetailRepository bidDetailRepository)
        {
            _bidDetailRepository = bidDetailRepository;
        }
        [Route("place-bid")]
        [HttpPost]
        public IActionResult AddProductDeatil(AddBidDetailsDto bidDetails)
        {
            try
            {
                ResponseModel responseModel = _bidDetailRepository.SaveBidDetail(bidDetails);
                if (responseModel == null)
                    return NotFound();

                return Ok(responseModel);
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }

        [Route("update-bid/{productId}/{buyerEmailId}/{newBidAmount}")]
        [HttpPost]
        public IActionResult UpdaeBidDeatil(int productId, string buyerEmailId, int newBidAmount)
        {
            try
            {
                ResponseModel responseModel = _bidDetailRepository.UpdateBid(productId, buyerEmailId, newBidAmount);
                if (responseModel == null)
                    return NotFound();

                return Ok(responseModel);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
    }
}
