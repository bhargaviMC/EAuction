using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EAuctionApp.Dto
{
    public class AddBidDetailsDto
    {
        public int ProductId { get; set; }
        public int BidAmount { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(30), MinLength(5)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(25), MinLength(3)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public long Mobile { get; set; }

    }
}
