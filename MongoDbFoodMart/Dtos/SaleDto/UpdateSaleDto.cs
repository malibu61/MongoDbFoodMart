namespace MongoDbFoodMart.Dtos.SaleDto
{
    public class UpdateSaleDto
    {
        public string SaleId { get; set; }
        public int CountOfProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public string ProductId { get; set; }
    }
}
