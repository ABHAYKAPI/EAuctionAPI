using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace JwtAuthenticationManager.Models
{
    [Serializable, BsonIgnoreExtraElements]
    public class UserAccount
    {
        [BsonId, BsonElement("_id"), BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ID { get; set; }

        [BsonElement("user_name"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string UserName { get; set; }
        [BsonElement("password"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Passwrod { get; set; }
        [BsonElement("role"), BsonRepresentation(MongoDB.Bson.BsonType.String)]
        public string Role { get; set; }
    }
}
