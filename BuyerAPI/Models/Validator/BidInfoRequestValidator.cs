using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyerAPI.Models.Validator
{
    public static class BidInfoRequestValidator
    {
        public static bool isValid(this Product product)
        {
            if (product == null || product?.BidEndDate >= DateTime.Now)
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
            if (product == null || product?.BidEndDate >= DateTime.Today)
            {
                return false;
            }
            return true;
        }

        public static bool isValidProductFromDatabase(this Products product)
        {
            if (product == null || product?.BidEndDate <= DateTime.Today)
            {
                return false;
            }
            return true;
        }

        public static bool isValid(this SellerInfo sellerInfo)
        {
            if (sellerInfo == null)
            {
                return false;
            }
            return true;
        }
    }
}
