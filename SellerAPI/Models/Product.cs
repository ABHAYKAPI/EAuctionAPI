using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    public class Product
    {
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Product name should not less then 3 character and not more then 30 character")]

        public string ProductName { get; set; }
        [Required]
        public string ShortDescription { get; set; }
        [Required]
        public string DetailDescription { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public decimal StartingPrice { get; set; }
        [Required]
        public DateTime BidEndDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
    }
}
