using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catatalog.Dtos.CategoryDtos;
using MultiShop.Catatalog.Entities;
using MultiShop.Catatalog.Settings;
using ZstdSharp.Unsafe;

namespace MultiShop.Catatalog.Services.CategoryServices {
    public class CategoryService : ICategoryService {

        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto) {
            var value = mapper.Map<Category>(createCategoryDto);
            await _categoryCollection.InsertOneAsync(value);
        }

        public async Task DeleteCategoryAsync(string id) {
            await _categoryCollection.DeleteOneAsync(x=>x.CategoryID==id);   
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoryAsync() {
            var values = await _categoryCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultCategoryDto>>(values);
        }

        public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id) {
            var values =await _categoryCollection.Find<Category>(x=> x.CategoryID==id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdCategoryDto>(values);
        }

        public async Task UpdateCategoryDtoAsync(UpdateCategoryDto updateCategoryDto) {
            var values = mapper.Map<Category>(updateCategoryDto);
            await _categoryCollection.FindOneAndReplaceAsync(x => x.CategoryID == updateCategoryDto.CategoryId,values);
        }
    }
}
