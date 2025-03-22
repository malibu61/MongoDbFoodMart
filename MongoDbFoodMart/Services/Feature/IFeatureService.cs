using MongoDbFoodMart.Dtos.FeatureDto;

namespace MongoDbFoodMart.Services.Feature
{
    public interface IFeatureService
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();
        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureDto(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);
        Task<List<ResultFeatureDto>> Get2FeatureAsync();
        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
