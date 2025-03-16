using MongoDbFoodMart.Dtos.SaleDto;

namespace MongoDbFoodMart.Services.Sale
{
    public interface ISaleService
    {
        Task<List<ResultSaleDto>> GetAllSaleAsync();
        Task CreateSaleAsync(CreateSaleDto createSaleDto);
        Task UpdateSaleDto(UpdateSaleDto updateSaleDto);
        Task DeleteSaleAsync(string id);
        Task<GetByIdSaleDto> GetByIdSaleAsync(string id);
    }
}
