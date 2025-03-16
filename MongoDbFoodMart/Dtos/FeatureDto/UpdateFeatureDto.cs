namespace MongoDbFoodMart.Dtos.FeatureDto
{
    public class UpdateFeatureDto
    {
        public string FeatureId { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? CategoryId { get; set; }
        public string? ProductId { get; set; }
    }
}
