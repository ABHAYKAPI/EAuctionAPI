using BuyerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuyerAPI.IServices
{
    public interface IProductInfoService
    {
        Task<Response> placeBid(SellerInfo sellerInfo);
        Task<Response> updateBid(string productID, string emailID, decimal amount);
    }
}
