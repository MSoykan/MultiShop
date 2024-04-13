using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catatalog.Dtos.ProductImageDtos;
using MultiShop.Catatalog.Entities;
using MultiShop.Catatalog.Settings;

namespace MultiShop.Catatalog.Services.ProductImageServices {
    public class ProductImageService : IProductImageService {

        private readonly IMongoCollection<ProductImage> _ProductImageCollection;
        private readonly IMapper mapper;

        public ProductImageService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductImageCollection = database.GetCollection<ProductImage>(_databaseSettings.ProductImageCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto) {
            var value = mapper.Map<ProductImage>(createProductImageDto);
            await _ProductImageCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductImageAsync(string id) {
            await _ProductImageCollection.DeleteOneAsync(x => x.ProductImageID == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync() {
            var values = await _ProductImageCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id) {
            var values = await _ProductImageCollection.Find<ProductImage>(x => x.ProductImageID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageDtoAsync(UpdateProductImageDto updateProductImageDto) {
            var values = mapper.Map<ProductImage>(updateProductImageDto);
            await _ProductImageCollection.FindOneAndReplaceAsync(x => x.ProductImageID == updateProductImageDto.ProductImageID, values);
        }
    }
}
