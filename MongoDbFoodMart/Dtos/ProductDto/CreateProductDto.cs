namespace MongoDbFoodMart.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductImageURL { get; set; }
        public string? ProductUnit { get; set; }
        public string? ProductRate { get; set; }
        public string CategoryId { get; set; }
        //public string CategoryName { get; set; }
    }
}
