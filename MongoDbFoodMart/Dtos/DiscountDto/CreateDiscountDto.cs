namespace MongoDbFoodMart.Dtos.DiscountDto
{
    public class CreateDiscountDto
    {
        public string Title { get; set; }
        public int DiscountRate { get; set; }
        public string FeatureImageURL { get; set; }
    }
}
