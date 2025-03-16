using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDbFoodMart.Dtos.ProductDto
{
    public class ResultProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
