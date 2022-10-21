using ProductAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.IServices
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISellerService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<Response> GetProducts();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<Response>  AddProduct(Product product);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        Task<Response> DeleteProduct(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Response> GetShowBidbyProductID(string id);
    }
}
