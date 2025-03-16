namespace MongoDbFoodMart.Dtos.DiscountDto
{
    public class UpdateDiscountDto
    {
        public string DiscountId { get; set; }
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string FeatureImageURL { get; set; }
    }
}
