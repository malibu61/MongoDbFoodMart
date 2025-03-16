namespace MongoDbFoodMart.Dtos.SaleDto
{
    public class CreateSaleDto
    {
        public int CountOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductId { get; set; }
    }
}
