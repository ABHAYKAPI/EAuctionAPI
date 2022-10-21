using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductAPI.IServices;
using ProductAPI.Models;
using ProductAPI.Models.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductAPI.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SellerService : ISellerService
    {
        private readonly IMongoCollection<Products> _productInfoCollection;
        private readonly IMongoCollection<SellerInfos> _sellerInfoCollection;

        //  APICoreDBContext dbContext;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setting"></param>
        /// <param name="mongoClient"></param>
        public SellerService(IEAuctionStoreDatabaseSetting setting, IMongoClient mongoClient)
        {
            //dbContext = _db;

            var database = mongoClient.GetDatabase(setting.DatabaseName);
            _productInfoCollection = database.GetCollection<Products>("product");
            _sellerInfoCollection = database.GetCollection<SellerInfos>("SellerInfo");
        }

        /// <summary>
        /// Return all product which is less then today's date
        /// </summary>
        /// <returns></returns>
        public async Task<Response> GetProducts()
        {
            Response res = new Response();
            try
            {
                var products = await _productInfoCollection.Find(x => x.BidEndDate >= DateTime.Today).ToListAsync();
                string json = JsonSerializer.Serialize<List<Products>>(products);
                res.StatusCode = (int)HttpStatusCode.OK;
                res.Message = "Data fetched successfully!";
                res.Data = json;
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
        /// ckdnkmdlfjks
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task<Response> AddProduct(Product product)
        {
            Response res = new Response();

            Products prod = new Products();
            prod.ProductName = product.ProductName;
            prod.ShortDescription = product.ShortDescription;
            prod.DetailDescription = product.DetailDescription;
            prod.BidEndDate = product.BidEndDate;
            prod.CreatedBy = "System";
            prod.Category = product.Category;
            prod.StartingPrice = product.StartingPrice;

            try
            {
                if (product.isValid())
                {
                    await _productInfoCollection.InsertOneAsync(prod);

                    res.StatusCode = (int)HttpStatusCode.OK;
                    res.Message = "Record successfully created!";

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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> DeleteProduct(string id)
        {
            Response res = new Response();

            var filterDefinition = Builders<Products>.Filter.Eq(x => x.ProductID, id);
            var product = await _productInfoCollection.Find(filterDefinition).SingleOrDefaultAsync();

            try
            {
                if (product.isValidProduct())
                {
                    await _productInfoCollection.DeleteOneAsync(filterDefinition);
                    res.StatusCode = (int)HttpStatusCode.OK;
                    res.Message = "Record successfully deleted!";
                }
                else
                {
                    var filterDefinitions = Builders<SellerInfos>.Filter.Eq(x => x.ProductID, id);
                    var sellerinfo = await _sellerInfoCollection.Find(filterDefinitions).SingleOrDefaultAsync();

                    if (sellerinfo == null)
                    {
                        await _productInfoCollection.DeleteOneAsync(filterDefinition);
                        res.StatusCode = (int)HttpStatusCode.OK;
                        res.Message = "Record successfully deleted!";
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
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Response> GetShowBidbyProductID(string id)
        {
            Response res = new Response();
            BidInfo bid = new BidInfo();

            try
            {
                var filterDefinition = Builders<Products>.Filter.Eq(x => x.ProductID, id);
                var product = await _productInfoCollection.Find(filterDefinition).SingleOrDefaultAsync();

                if (product != null)
                {
                    var filterDefinitions = Builders<SellerInfos>.Filter.Eq(x => x.ProductID, id);
                    var seller = await _sellerInfoCollection.Find(filterDefinitions).ToListAsync();

                    bid.ProductID = product.ProductID;
                    bid.ProductName = product.ProductName;
                    bid.ShortDescription = product.ShortDescription;
                    bid.DetailDescription = product.DetailDescription;
                    bid.Category = product.Category;
                    bid.StartingPrice = product.StartingPrice;
                    bid.BidEndDate = product.BidEndDate;
                    bid.seller = seller;

                    string json = JsonSerializer.Serialize<BidInfo>(bid);
                    res.StatusCode = (int)HttpStatusCode.OK;
                    res.Message = "Data fetched successfully!";
                    res.Data = json;
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
