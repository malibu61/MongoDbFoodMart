using AutoMapper;
using MongoDB.Driver;
using MongoDbFoodMart.Dtos.FeatureDto;
using MongoDbFoodMart.Services.Feature;
using MongoDbFoodMart.Settings;

namespace MongoDbFoodMart.Services.Feature
{
    public class FeatureService : IFeatureService
    {
        private readonly IMongoCollection<MongoDbFoodMart.Entities.Feature> _featureCollection;
        private readonly IMapper _mapper;

        public FeatureService(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);//Bağlantı adresi
            var database = client.GetDatabase(_databaseSettings.DatabaseName);//Veritabanı adı
            _featureCollection = database.GetCollection<MongoDbFoodMart.Entities.Feature>(_databaseSettings.FeatureCollectionName); //İlgili Collection
            _mapper = mapper;
        }

        public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Feature>(createFeatureDto);
            await _featureCollection.InsertOneAsync(values);
        }

        public async Task DeleteFeatureAsync(string id)
        {
            await _featureCollection.DeleteOneAsync(x => x.FeatureId == id);
        }

        public async Task<List<ResultFeatureDto>> Get2FeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            values = values.OrderBy(x => x.FeatureId).Take(2).ToList();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
        {
            var values = await _featureCollection.Find(x => true).ToListAsync();
            values = values.OrderByDescending(x => x.FeatureId).ToList();
            return _mapper.Map<List<ResultFeatureDto>>(values);
        }

        public async Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id)
        {
            var values = await _featureCollection.Find(x => x.FeatureId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdFeatureDto>(values);

        }

        public async Task UpdateFeatureDto(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<MongoDbFoodMart.Entities.Feature>(updateFeatureDto);
            await _featureCollection.FindOneAndReplaceAsync(x => x.FeatureId == updateFeatureDto.FeatureId, values);
        }
    }
}
