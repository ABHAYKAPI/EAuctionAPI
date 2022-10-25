using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BuyerAPI.IServices;
using BuyerAPI.Models;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuyerAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BuyerController : ControllerBase
    {
        private readonly IProductInfoService sellerInfos;

        /// <summary>
        /// Constructor for initiliazingi the product service
        /// </summary>
        /// <param name="sellerInfo"></param>
        public BuyerController(IProductInfoService sellerInfo)
        {
            sellerInfos = sellerInfo;
        }

        /// <summary>
        /// This the function where buyer can place a bid for particular product
        /// </summary>
        /// <param name="sellerInfo"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("PlaceBid")]
        public async Task<IActionResult> PlaceBid(SellerInfo sellerInfo)
        {
            var response = await sellerInfos.placeBid(sellerInfo);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// This is the function to update bid amount with the help of product id and email
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="emailID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateBid/{productID}/{emailID}/{amount}")]
        public async Task<IActionResult> UpdateBidAmount(string productID, string emailID, decimal amount)
        {
            var response = await sellerInfos.updateBid(productID, emailID, amount);
            return new OkObjectResult(response);
        }
    }
}
