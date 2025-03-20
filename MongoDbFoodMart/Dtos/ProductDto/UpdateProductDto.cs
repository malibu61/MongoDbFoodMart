namespace MongoDbFoodMart.Dtos.ProductDto
{
    public class UpdateProductDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string? ProductUnit { get; set; }
        public string? ProductRate { get; set; }
        public string CategoryId { get; set; }
    }
}
