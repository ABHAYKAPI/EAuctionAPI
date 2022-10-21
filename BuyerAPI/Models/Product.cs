using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerAPI.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string ProductID { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Product name should not less then 3 character and not more then 30 character")]

        public string ProductName { get; set; }
        public string ShortDescription { get; set; }
        public string DetailDescription { get; set; }
        public string Category { get; set; }
        public decimal StartingPrice { get; set; }
        public DateTime BidEndDate { get; set; }
        public string CreatedBy { get; set; }
    }
}
