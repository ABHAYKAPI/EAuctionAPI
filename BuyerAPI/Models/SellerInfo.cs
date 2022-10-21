using System;
using System.ComponentModel.DataAnnotations;


namespace BuyerAPI.Models
{
    public class SellerInfo
    {

        [Required]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "First name should not less then 5 character and not more then 30 character")]

        public string FirstName { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Last name should not less then 3 character and not more then 30 character")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [Required(ErrorMessage = "Pin is required")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Pin Should be 6 digit")]
        [RegularExpression("^[0-9]*$",ErrorMessage = "Pin should be numeric only")]
        public string Pin { get; set; }
        [Required(ErrorMessage = "Pin is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Pone Should be 10 digit")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone should be numeric only")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address")]
        public string Email { get; set; }
        public string ProductID { get; set; }
        public decimal BidAMount { get; set; }
        public string CreatedBy { get; set; }
    }
}
