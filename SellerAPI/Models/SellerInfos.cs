using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace ProductAPI.Models
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable, BsonIgnoreExtraElements]
    public class SellerInfos
    {
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("_bidid"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BidID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("first_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("last_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("address"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("city"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("state"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("pin"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Pin { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("phone"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Phone { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("product_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ProductID { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("bid_amount"), BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal BidAMount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("created_by"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CreatedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [BsonElement("created_date"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
