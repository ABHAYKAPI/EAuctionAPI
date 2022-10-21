using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, BsonIgnoreExtraElements]
    public class BidInfo
    {
        /// <summary>
        /// 
        /// </summary>
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("product_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ProductID { get; set; }
        /// <summary>
        /// 
        /// </summary>

        [BsonElement("product_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ProductName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("short_description"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ShortDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ BsonElement("detail_description"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string DetailDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("cateagory"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("starting_price"), BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal StartingPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("bid_enddate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime BidEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("created_by"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<SellerInfos> seller { get; set; }

    }
}
