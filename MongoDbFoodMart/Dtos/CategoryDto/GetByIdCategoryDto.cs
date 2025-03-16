namespace MongoDbFoodMart.Dtos.CategoryDto
{
    public class GetByIdCategoryDto
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImageURL { get; set; }
    }
}
