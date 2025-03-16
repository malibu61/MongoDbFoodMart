using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.DiscountDto;
using MongoDbFoodMart.Services.Discount;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Discount
{
    public class DiscountService : IDiscountService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Discount> _discountCollection;
        private readonly IMapper _mapper;

        public DiscountService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _discountCollection = database.GetCollection<MongoDbFoodMart.Entities.Discount>(_databaseSettings.DiscountCollectionName); //İlgili Collection
            _mapper = mapper;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Discount>(createDiscountDto);
            await _discountCollection.InsertOneAsync(values);
        }

        public async Task DeleteDiscountAsync(string id)
        {
            await _discountCollection.DeleteOneAsync(x => x.DiscountId == id);
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            var values = await _discountCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultDiscountDto>>(values);
        }

        public async Task<GetByIdDiscountDto> GetByIdDiscountAsync(string id)
        {
            var values = await _discountCollection.Find(x => x.DiscountId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdDiscountDto>(values);

        }

        public async Task UpdateDiscountDto(UpdateDiscountDto updateDiscountDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Discount>(updateDiscountDto);
            await _discountCollection.FindOneAndReplaceAsync(x => x.DiscountId == updateDiscountDto.DiscountId, values);
        }
    }
}
