using System.ComponentModel.DataAnnotations;
namespace EAuctionApp.Dto
{
    public class SaveProductDetailsDto
    {

        [Required]
        [MaxLength(30), MinLength(5)]
        public string ProductName { get; set; }
        public string ProductShortDescription { get; set; }
        public string ProductLongDescription { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        public DateTime BidEndDate { get; set; }


        [Required]
        [MaxLength(30), MinLength(5)]
        public string SellerFirstName { get; set; }

        [Required]
        [MaxLength(25), MinLength(3)]
        public string SellerLastName { get; set; }
        public string SellerAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string SellerZipCode { get; set; }
        public long SellerMobile { get; set; }

        [EmailAddress]
        public string Email { get; set; }

    }
}
