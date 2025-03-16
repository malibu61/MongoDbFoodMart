namespace MongoDbFoodMart.Dtos.CategoryDto
{
    public class UpdateCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImageURL { get; set; }
    }
}
