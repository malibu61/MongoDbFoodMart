namespace MongoDbFoodMart.Dtos.DiscountDto
{
    public class GetByIdDiscountDto
    {
        public string DiscountId { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string FeatureImageURL { get; set; }
    }
}
