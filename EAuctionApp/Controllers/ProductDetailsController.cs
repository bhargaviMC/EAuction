using EAuctionApp.Authentication;
using EAuctionApp.Dto;
using EAuctionApp.Model;
using EAuctionApp.Repository;
using EAuctionApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EAuctionApp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {

        IProductDetailRepository _productService;
        public ProductDetailsController(IProductDetailRepository productService)
        {
            _productService = productService;
        }
        //GET: api/<ProductDetailsController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ProductDetails> product = _productService.GetAllProducts();
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
                
            }
            
        }

        // GET api/<ProductDetailsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                IQueryable<ProductDetails> product = _productService.GetProductByID(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        // POST api/<ProductDetailsController>
        [HttpPost]
        public IActionResult Post(SaveProductDetailsDto productDetails)
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

        // PUT api/<ProductDetailsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(ProductDetails productDetails)
        {
            try
            {
                ResponseModel product = _productService.UpdateProductDetails(productDetails);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();

            }
        }

        // DELETE api/<ProductDetailsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            try
            {
                ResponseModel product = _productService.DeleteProduct(id);
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
