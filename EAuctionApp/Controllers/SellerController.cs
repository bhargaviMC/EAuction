using EAuctionApp.Dto;
using EAuctionApp.Model;
using EAuctionApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EAuctionApp.Authentication;

namespace EAuctionApp.Controllers
{
    [Authorize(Roles = UserRoles.Seller)]
    [Route("e-auction/api/v1/seller")]
    [ApiController]
    
    public class SellerController : ControllerBase
    {
        

        IProductDetailRepository _productService;
        public SellerController(IProductDetailRepository productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// This action method is used for adding new Product detail by the seller
        /// </summary>
        /// <param name="productDetails"></param>
        /// <returns></returns>
        [Route("add-product")]
        [HttpPost]
        public IActionResult AddProductDeatil(SaveProductDetailsDto productDetails)
        {
            try
            {
                ResponseModel product = _productService.SaveProductDetail(productDetails);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();

            }

        }
        [Route("show-bids/{productId}")]
        [HttpGet]
        public IActionResult GetById(int productId)
        {
            try
            {
                ProductWithBidsDto product = _productService.GetPrdocutAlongWithBids(productId);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        [Route("delete/{productId}")]
        [HttpDelete]
        public IActionResult Delete(int productId)
        {

            try
            {
                ResponseModel product = _productService.DeleteProduct(productId);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }
    }
}
