using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.CategoryDto;
using MongoDbFoodMart.Entities;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Category> _categoryCollection;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _categoryCollection = database.GetCollection<MongoDbFoodMart.Entities.Category>(_databaseSettings.CategoryCollectionName); //İlgili Collection
            _mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(values);
        }

        public async Task DeleteCategoryAsync(string id)
        {
            await _categoryCollection.DeleteOneAsync(x => x.CategoryId == id);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
        {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return _mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
        {
            var values = await _categoryCollection.Find(x => x.CategoryId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdCategoryDto>(values);

        }

        public async Task UpdateCategoryDto(UpdateCategoryDto updateCategoryDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, values);
        }
    }
}
