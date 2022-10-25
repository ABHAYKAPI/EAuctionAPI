using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using ProductAPI.IServices;
using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService productService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        public SellerController(ISellerService product)
        {
            productService = product;
        }

        /// <summary>
        /// Api for Getting number of bid details against product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await productService.GetProducts();
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Api for adding product 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            var response = await productService.AddProduct(product);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Api for Getting number of bid details against product id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ShowBids/{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var response = await productService.GetShowBidbyProductID(id);
            return new OkObjectResult(response);
        }

        /// <summary>
        /// Api for deleting the product if no any bid is placed against this product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpDelete]
        //[Authorize(Roles = "Seller")]
        [Route("Delete/{productId}")]
        public async Task<IActionResult> DeleteProduct(string productId)
        {
            var response = await productService.DeleteProduct(productId);
            return new OkObjectResult(response);
        }
    }
}
