using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDbFoodMart.Entities;

namespace MongoDbFoodMart.Dtos.SaleDto
{
    public class ResultSaleDto
    {
        public string SaleId { get; set; }
        public int CountOfProducts { get; set; }
        public string ProductId { get; set; }



        public string ProductName { get; set; }//
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string? ProductUnit { get; set; }//
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
