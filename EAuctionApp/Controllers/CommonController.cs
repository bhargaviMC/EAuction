using EAuctionApp.Authentication;
using EAuctionApp.Dto;
using EAuctionApp.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EAuctionApp.Controllers
{
    [Authorize(Roles = UserRoles.Seller + "," +  UserRoles.Buyer)]
    [Route("e-auction/api/v1/common")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        IProductDetailRepository _productService;
        public CommonController(IProductDetailRepository productService)
        {
            _productService = productService;
        }

        [Route("show-productlist")]
        [HttpGet]
        public IActionResult GetById(int productId)
        {
            try
            {
                List<ProductListForDisplayDto> product = _productService.GetProductListForDisplays();
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
