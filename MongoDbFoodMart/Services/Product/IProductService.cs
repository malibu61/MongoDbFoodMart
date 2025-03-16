using MongoDbFoodMart.Dtos.ProductDto;

namespace MongoDbFoodMart.Services.Product
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductDto(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);
        Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string id);
    }
}
