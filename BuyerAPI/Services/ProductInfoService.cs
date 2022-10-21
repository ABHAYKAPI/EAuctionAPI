using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using BuyerAPI.IServices;
using BuyerAPI.Models;
using BuyerAPI.Models.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BuyerAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductInfoService : IProductInfoService
    {
        private readonly IMongoCollection<Products> _productInfoCollection;
        private readonly IMongoCollection<SellerInfos> _sellerInfoCollection;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="mongoClient"></param>
        public ProductInfoService(IEAuctionStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _productInfoCollection = database.GetCollection<Products>("product");
            _sellerInfoCollection = database.GetCollection<SellerInfos>("SellerInfo");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sellerInfos"></param>
        /// <returns></returns>
        public async Task<Response> placeBid(SellerInfo sellerInfos)
        {
            Response res = new Response();

            try
            {
                if (sellerInfos.isValid())
                {
                    var filterDefinition = Builders<Products>.Filter.Eq(x => x.ProductID, sellerInfos.ProductID);
                    var product = await _productInfoCollection.Find(filterDefinition).SingleOrDefaultAsync();

                    if (product.isValidProductFromDatabase())
                    {
                        SellerInfos seller = new SellerInfos
                        {
                            FirstName = sellerInfos.FirstName,
                            LastName = sellerInfos.LastName,
                            Address = sellerInfos.Address,
                            State = sellerInfos.State,
                            City = sellerInfos.City,
                            Pin = sellerInfos.Pin,
                            Phone = sellerInfos.Phone,
                            ProductID = sellerInfos.ProductID,
                            BidAMount = sellerInfos.BidAMount,
                            CreatedBy = "System",
                            CreatedDate = DateTime.Now
                        };

                        await _sellerInfoCollection.InsertOneAsync(seller);

                        res.StatusCode = (int)HttpStatusCode.OK;
                        res.Message = "Record successfully created!";
                    }
                    else
                    {
                        res.StatusCode = (int)HttpStatusCode.BadRequest;
                        res.Message = "Error occured!";
                    }
                }
            }
            catch (Exception ex)
            {
                ProblemDetails problemDetails = new ProblemDetails();
                problemDetails.Detail = ex.Message;
                problemDetails.Title = ex.Message;

                res.problemDetails = problemDetails;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return res;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="emailID"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public async Task<Response> updateBid(string productID, string emailID, decimal amount)
        {
            Response res = new Response();

            try
            {
                var filterDefinition = Builders<SellerInfos>.Filter.Eq(x => x.ProductID, productID);
                var seller = await _sellerInfoCollection.Find(x => x.ProductID == productID && x.Email == emailID).SingleOrDefaultAsync();
                if (seller != null)
                {
                    seller.BidAMount = amount;
                    var Result = await _sellerInfoCollection.ReplaceOneAsync(x => x.ProductID == productID && x.Email == emailID, seller);

                    if (!Result.IsAcknowledged)
                    {
                        res.StatusCode = (int)HttpStatusCode.NotFound;
                        res.Message = "Input Id Not Found/ Updation Not Occurs.";
                    }
                    else
                    {
                        res.StatusCode = (int)HttpStatusCode.OK;
                        res.Message = "Record Updated Successfully.";
                    }
                }
            }
            catch (Exception ex)
            {
                ProblemDetails problemDetails = new ProblemDetails();
                problemDetails.Detail = ex.Message;
                problemDetails.Title = ex.Message;

                res.problemDetails = problemDetails;
                res.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return res;
        }
    }
}
