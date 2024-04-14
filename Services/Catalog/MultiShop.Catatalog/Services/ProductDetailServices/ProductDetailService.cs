using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catatalog.Dtos.ProductDetailsDtos;
using MultiShop.Catatalog.Entities;
using MultiShop.Catatalog.Settings;

namespace MultiShop.Catatalog.Services.ProductDetailServices {
    public class ProductDetailService : IProductDetailService {

        private readonly IMongoCollection<ProductDetail> _ProductDetailCollection;
        private readonly IMapper mapper;
        
        public ProductDetailService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _ProductDetailCollection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            this.mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto) {
            var value = mapper.Map<ProductDetail>(createProductDetailDto);
            await _ProductDetailCollection.InsertOneAsync(value);
        }

        public async Task DeleteProductDetailAsync(string id) {
            await _ProductDetailCollection.DeleteOneAsync(x => x.ProductDetailsID == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync() {
            var values = await _ProductDetailCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id) {
            var values = await _ProductDetailCollection.Find<ProductDetail>(x => x.ProductDetailsID == id).FirstOrDefaultAsync();
            return mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailDtoAsync(UpdateProductDetailDto updateProductDetailDto) {
            var values = mapper.Map<ProductDetail>(updateProductDetailDto);
            await _ProductDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailsID == updateProductDetailDto.ProductDetailsID, values);
        }
    }
}
