using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoDbFoodMart.Entities
{
    public class Sale
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SaleId { get; set; }
        public int CountOfProducts { get; set; }
        public decimal TotalPrice { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string ProductId { get; set; }
        [BsonIgnore]
        public Product Product { get; set; }
    }
}
