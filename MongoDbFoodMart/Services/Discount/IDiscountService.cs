using MongoDbFoodMart.Dtos.DiscountDto;

namespace MongoDbFoodMart.Services.Discount
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountDto>> GetAllDiscountAsync();
        Task CreateDiscountAsync(CreateDiscountDto createDiscountDto);
        Task UpdateDiscountDto(UpdateDiscountDto updateDiscountDto);
        Task DeleteDiscountAsync(string id);
        Task<GetByIdDiscountDto> GetByIdDiscountAsync(string id);
    }
}
