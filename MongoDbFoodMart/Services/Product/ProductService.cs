using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.ProductDto;
using MongoDbFoodMart.Services.Product;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Product> _productCollection;
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Category> _categoryCollection;
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _productCollection = database.GetCollection<MongoDbFoodMart.Entities.Product>(_databaseSettings.ProductCollectionName); //İlgili Collection
            _categoryCollection = database.GetCollection<MongoDbFoodMart.Entities.Category>(_databaseSettings.CategoryCollectionName); //İlgili Collection
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productCollection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productCollection.Find(x => true).ToListAsync();


            foreach (var item in values)
            {
                item.Category = await _categoryCollection.Find<MongoDbFoodMart.Entities.Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }

            return _mapper.Map<List<ResultProductDto>>(values);

        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id)
        {
            var values = await _productCollection.Find(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);

        }

        public async Task<List<ResultProductDto>> GetProductsByCategoryIdAsync(string id)
        {
            var values = await _productCollection.Find(x => x.CategoryId == id).ToListAsync();

            return values.Select(x => new ResultProductDto
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                Price = x.Price,
                CategoryId = x.CategoryId,
                CategoryName = x.CategoryName,
                ProductImageURL = x.ProductImageURL,
                ProductRate = x.ProductRate,
                ProductUnit = x.ProductUnit

            }).ToList();

        }

        public async Task UpdateProductDto(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
