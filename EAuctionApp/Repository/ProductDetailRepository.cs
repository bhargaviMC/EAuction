using EAuctionApp.ConstantClasses;
using EAuctionApp.Dto;
using EAuctionApp.Model;

namespace EAuctionApp.Repository
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        public AuctionContext _auctionContext;
        

        public ProductDetailRepository(AuctionContext auctionContext)
        {
            _auctionContext = auctionContext;
            
        }

        public List<ProductDetails> GetAllProducts()
        {
            return _auctionContext.Set<ProductDetails>().ToList();
        }

        public List<ProductListForDisplayDto> GetProductListForDisplays()
        {
            List<ProductListForDisplayDto> products = new List<ProductListForDisplayDto>();

            List<ProductDetails> _temp = GetAllProducts();

            foreach(ProductDetails prod in _temp)
            {
                ProductListForDisplayDto _tepmDetails = new ProductListForDisplayDto();
                _tepmDetails.ProductId = prod.ProductId;
                _tepmDetails.ProductName = prod.ProductName;
                products.Add(_tepmDetails);
            }

            return products;
        }

        public IQueryable<ProductDetails> GetProductByID(int id)
        {
            IQueryable<ProductDetails> product;
            try
            {
                product = _auctionContext.ProductDetails.Where(x => x.ProductId == id);
                
                
            }
            catch (Exception)
            {
                throw;
            }
            return product;
        }

        public ResponseModel SaveProductDetail(SaveProductDetailsDto product)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                CategoryDetails category = new CategoryDetails();
                
                if (!category.CheckCategory(product.ProductCategory))
                {
                    response.IsSuccess = false;
                    response.Messsage = "Category Not in List";
                    return response;
                }
                if(product.SellerMobile.ToString().Length != 10)
                {
                    response.IsSuccess = false;
                    response.Messsage = "Mobile Number should be 10 digit";
                    return response;
                }
                    ProductDetails _productDetails = new ProductDetails();
                    _productDetails.ProductName = product.productName;
                    _productDetails.ProductPrice = product.ProductPrice;
                    _productDetails.ProductShortDescription = product.ProductShortDescription;
                    _productDetails.ProductLongDescription = product.ProductLongDescription;
                    _productDetails.ProductCategory = product.ProductCategory;
                    _productDetails.BidEndDate = product.BidEndDate;
                    _productDetails.SellerFirstName = product.SellerFirstName;
                    _productDetails.SellerLastName = product.SellerLastName;
                    _productDetails.SellerAddress = product.SellerAddress;
                    _productDetails.State = product.State;
                    _productDetails.City = product.City;
                    _productDetails.SellerZipCode = product.SellerZipCode;
                    _productDetails.Email = product.Email;
                    _productDetails.SellerMobile = product.SellerMobile;
                    _auctionContext.Add<ProductDetails>(_productDetails);
                    response.Messsage = "Product Added Successfully";
                
                _auctionContext.SaveChanges();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messsage = "Unable to add the product" + ex.Message;
                return response;
            }

            return response;
        }

        public ResponseModel UpdateProductDetails(ProductDetails product)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                ProductDetails _temp = _auctionContext.Find<ProductDetails>(product.ProductId);
                if (_temp != null)
                {
                    _temp.ProductName = product.ProductName;
                    _temp.ProductPrice = product.ProductPrice;
                    _temp.ProductShortDescription = product.ProductShortDescription;
                    _temp.ProductLongDescription = product.ProductLongDescription;
                    _temp.ProductCategory = product.ProductCategory;
                    _temp.BidEndDate = product.BidEndDate;
                    _temp.SellerFirstName = product.SellerFirstName;
                    _temp.SellerLastName = product.SellerLastName;
                    _temp.SellerAddress = product.SellerAddress;
                    _temp.State = product.State;
                    _temp.City = product.City;
                    _temp.SellerZipCode = product.SellerZipCode;
                    _temp.Email = product.Email;
                    _temp.SellerMobile = product.SellerMobile;

                    _auctionContext.Update<ProductDetails>(_temp);
                    response.Messsage = "Product Update Successfully";
                }
                else
                {
                    response.IsSuccess = false;
                    response.Messsage = "Specified Product is not Present";
                }
                _auctionContext.SaveChanges();
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Messsage = "Unable to add the product" + ex.Message;
                throw;
            }

            return response;
        }

        public ResponseModel DeleteProduct(int productId)
        {
            ResponseModel model = new ResponseModel();
            try
            {
                ProductDetails _temp = _auctionContext.Find<ProductDetails>(productId);
                if (_temp != null)
                {
                    if(_temp.BidEndDate < DateTime.Now)
                    {
                        model.IsSuccess = false;
                        model.Messsage = "Product cannot be deleted after Bid End Date";
                        return model;
                    }
                    

                    _auctionContext.Remove<ProductDetails>(_temp);
                    _auctionContext.SaveChanges();
                    model.IsSuccess = true;
                    model.Messsage = "Product Deleted Successfully";
                }
                else
                {
                    model.IsSuccess = false;
                    model.Messsage = "Product Not Found";
                }
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ProductWithBidsDto GetPrdocutAlongWithBids(int productId)
        {
            ProductWithBidsDto model = new ProductWithBidsDto();

            IQueryable<ProductDetails> product = GetProductByID(productId);
            

            List<BidDetails> bids = _auctionContext.BidDetails.Where(x => x.ProductId == productId).ToList();

            if (product.Count() > 0)
            {

                model.bidDetails = bids;
                model.ProductId = productId;
                model.ProductName = product.First().ProductName;
                model.ProductPrice = product.First().ProductPrice;
                model.ProductLongDescription = product.First().ProductLongDescription;
                model.ProductShortDescription = product.First().ProductShortDescription;
                model.BidEndDate = product.First().BidEndDate;
                model.ProductCategory = product.First().ProductCategory;

            }


            return model;
        }
    }
}
