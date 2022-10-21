using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models.Validator
{
    public static class ProductRequestValidator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool isValid(this Product product)
        {
            if (product == null || product?.BidEndDate <= DateTime.Now)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static bool isValidProduct(this Products product)
        {
            if (product == null || product?.BidEndDate <= DateTime.Today)
            {
                return false;
            }
            return true;
        }


    }
}
