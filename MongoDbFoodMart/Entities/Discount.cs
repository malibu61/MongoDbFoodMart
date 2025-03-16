using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace MongoDbFoodMart.Entities
{
    public class Discount
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DiscountId { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string FeatureImageURL { get; set; }
    }
}
