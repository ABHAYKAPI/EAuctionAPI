using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;


namespace BuyerAPI.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class SellerInfos
    {
        [BsonElement("_bidid"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string BidID { get; set; }
        [BsonElement("first_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string FirstName { get; set; }
        [BsonElement("last_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string LastName { get; set; }
        [BsonElement("address"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Address { get; set; }
        [BsonElement("city"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string City { get; set; }
        [BsonElement("state"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string State { get; set; }
        [BsonElement("pin"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Pin { get; set; }
        [BsonElement("phone"), BsonRepresentation(MongoDB.Bson.BsonType.String)]

        public string Phone { get; set; }
        [BsonElement("email"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Email { get; set; }
        [BsonElement("product_id"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string ProductID { get; set; }
        [BsonElement("bid_amount"), BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal BidAMount { get; set; }
        [BsonElement("created_by"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string CreatedBy { get; set; }
        [BsonElement("created_date"), BsonRepresentation(MongoDB.Bson.BsonType.DateTime)]
        public DateTime CreatedDate { get; set; }
    }
}
