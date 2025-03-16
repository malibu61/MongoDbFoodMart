using MongoDbFoodMart.Dtos.DepartmentDto;

namespace MongoDbFoodMart.Services.Department
{
    public interface IDepartmentService
    {
        Task<List<ResultDepartmentDto>> GetAllDepartmentAsync();
        Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto);
        Task UpdateDepartmentDto(UpdateDepartmentDto updateDepartmentDto);
        Task DeleteDepartmentAsync(string id);
        Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string id);
    }
}
