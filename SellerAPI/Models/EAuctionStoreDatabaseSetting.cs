using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class EAuctionStoreDatabaseSetting : IEAuctionStoreDatabaseSetting
    {
        /// <summary>
        /// 
        /// </summary>
        public string EAuctionSellInfoCollectionName { get; set; } = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string ConnectionString { get; set; } = String.Empty;
        /// <summary>
        /// 
        /// </summary>
        public string DatabaseName { get; set; } = String.Empty;
    }
}
