using MongoDbFoodMart.Dtos.CategoryDto;
using MongoDbFoodMart.Dtos.CustomerDto;

namespace MongoDbFoodMart.Services.Category
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryDto(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
