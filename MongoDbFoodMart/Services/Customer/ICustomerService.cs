using MongoDbFoodMart.Dtos.CustomerDto;

namespace MongoDbFoodMart.Services.Customer
{
    public interface ICustomerService
    {
        Task<List<ResultCustomerDto>> GetAllCustomerAsync();
        Task CreateCustomerAsync(CreateCustomerDto createCustomerDto);
        Task UpdateCustomerDto(UpdateCustomerDto updateCustomerDto);
        Task DeleteCustomerAsync(string id);
        Task<GetByIdCustomerDto> GetByIdCustomerAsync(string id);
    }
}
