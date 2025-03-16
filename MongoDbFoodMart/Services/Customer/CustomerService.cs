using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.CustomerDto;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Customer> _customerCollection;
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Department> _departmentCollection;
        private readonly IMapper _mapper;

        public CustomerService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _customerCollection = database.GetCollection<MongoDbFoodMart.Entities.Customer>(_databaseSettings.CustomerCollectionName); //İlgili Collection
            _departmentCollection = database.GetCollection<MongoDbFoodMart.Entities.Department>(_databaseSettings.DepartmentCollectionName);
            _mapper = mapper;
        }

        public async Task CreateCustomerAsync(CreateCustomerDto createCustomerDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Customer>(createCustomerDto);
            await _customerCollection.InsertOneAsync(values);
        }

        public async Task DeleteCustomerAsync(string id)
        {
            await _customerCollection.DeleteOneAsync(x => x.CustomerId == id);
        }

        public async Task<List<ResultCustomerDto>> GetAllCustomerAsync()
        {
            var values = await _customerCollection.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                item.Department = await _departmentCollection.Find<MongoDbFoodMart.Entities.Department>(x => x.DepartmentId == item.DepartmentId).FirstAsync();
            }

            return _mapper.Map<List<ResultCustomerDto>>(values);
        }

        public async Task<GetByIdCustomerDto> GetByIdCustomerAsync(string id)
        {
            var values = await _customerCollection.Find(x => x.CustomerId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCustomerDto>(values);

        }

        public async Task UpdateCustomerDto(UpdateCustomerDto updateCustomerDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Customer>(updateCustomerDto);
            await _customerCollection.FindOneAndReplaceAsync(x => x.CustomerId == updateCustomerDto.CustomerId, values);
        }
    }
}
