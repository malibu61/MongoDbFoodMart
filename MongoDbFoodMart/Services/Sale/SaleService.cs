using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.CustomerDto;
using MongoDbFoodMart.Dtos.SaleDto;
using MongoDbFoodMart.Services.Sale;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Sale
{
    public class SaleService : ISaleService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Sale> _saleCollection;
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Product> _productCollection;
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Category> _categoryCollection;
        private readonly IMapper _mapper;

        public SaleService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _saleCollection = database.GetCollection<MongoDbFoodMart.Entities.Sale>(_databaseSettings.SaleCollectionName); //İlgili Collection
            _productCollection = database.GetCollection<MongoDbFoodMart.Entities.Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<MongoDbFoodMart.Entities.Category>(_databaseSettings.CategoryCollectionName);

            _mapper = mapper;
        }

        public async Task CreateSaleAsync(CreateSaleDto createSaleDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Sale>(createSaleDto);
            await _saleCollection.InsertOneAsync(values);
        }

        public async Task DeleteSaleAsync(string id)
        {
            await _saleCollection.DeleteOneAsync(x => x.SaleId == id);
        }

        public async Task<List<ResultSaleDto>> GetAllSaleAsync()
        {




            var values = await _saleCollection.Find(x => true).ToListAsync();

            foreach (var item in values)
            {
                item.Product = await _productCollection.Find<MongoDbFoodMart.Entities.Product>(x => x.ProductId == item.ProductId).FirstAsync();
                item.Product.Category = await _categoryCollection.Find<MongoDbFoodMart.Entities.Category>(x => x.CategoryId == item.Product.CategoryId).FirstAsync();
            }

            return _mapper.Map<List<ResultSaleDto>>(values);
        }

        public async Task<GetByIdSaleDto> GetByIdSaleAsync(string id)
        {
            var values = await _saleCollection.Find(x => x.SaleId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdSaleDto>(values);

        }

        public async Task UpdateSaleDto(UpdateSaleDto updateSaleDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Sale>(updateSaleDto);
            await _saleCollection.FindOneAndReplaceAsync(x => x.SaleId == updateSaleDto.SaleId, values);
        }
    }
}
