using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbFoodMart.Entities
{
    public class Feature
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string FeatureId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? CategoryId { get; set; }

        [BsonIgnore]
        public Category Category { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string? ProductId { get; set; }

        [BsonIgnore]
        public Product Product { get; set; }
    }
}
