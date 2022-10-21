using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class Products
    {
        [BsonId, BsonElement("product_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductID { get; set; }

        [BsonElement("product_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ProductName { get; set; }
        [BsonElement("short_description"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ShortDescription { get; set; }
        [ BsonElement("detail_description"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string DetailDescription { get; set; }
        [BsonElement("cateagory"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Category { get; set; }
        [BsonElement("starting_price"), BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal StartingPrice { get; set; }
        [BsonElement("bid_enddate"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime BidEndDate { get; set; }
        [BsonElement("created_by"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CreatedBy { get; set; }
       
    }
}
