using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.DepartmentDto;
using MongoDbFoodMart.Services.Department;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Department
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Department> _departmentCollection;
        private readonly IMapper _mapper;

        public DepartmentService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _departmentCollection = database.GetCollection<MongoDbFoodMart.Entities.Department>(_databaseSettings.DepartmentCollectionName); //İlgili Collection
            _mapper = mapper;
        }

        public async Task CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Department>(createDepartmentDto);
            await _departmentCollection.InsertOneAsync(values);
        }

        public async Task DeleteDepartmentAsync(string id)
        {
            await _departmentCollection.DeleteOneAsync(x => x.DepartmentId == id);
        }

        public async Task<List<ResultDepartmentDto>> GetAllDepartmentAsync()
        {
            var values = await _departmentCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDepartmentDto>>(values);
        }

        public async Task<GetByIdDepartmentDto> GetByIdDepartmentAsync(string id)
        {
            var values = await _departmentCollection.Find(x => x.DepartmentId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDepartmentDto>(values);

        }

        public async Task UpdateDepartmentDto(UpdateDepartmentDto updateDepartmentDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Department>(updateDepartmentDto);
            await _departmentCollection.FindOneAndReplaceAsync(x => x.DepartmentId == updateDepartmentDto.DepartmentId, values);
        }
    }
}
