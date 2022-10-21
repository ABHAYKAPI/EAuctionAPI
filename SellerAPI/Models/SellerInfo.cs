using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{

    public class SellerInfo
    {
        public int ID { get; set; }

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
        public string Pin { get; set; }

        public int Phone { get; set; }

        [Required(ErrorMessage = "The Email field is required")]
        [EmailAddress(ErrorMessage = "The Email field is not a valid e-mail address")]
        public string Email { get; set; }
        public string ProductID { get; set; }
        public decimal BidAMount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
