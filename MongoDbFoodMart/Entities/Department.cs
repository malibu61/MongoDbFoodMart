using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDbFoodMart.Entities
{
    public class Department
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
