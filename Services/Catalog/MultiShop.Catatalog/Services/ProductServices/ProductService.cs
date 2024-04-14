using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catatalog.Dtos.ProductDtos;
using MultiShop.Catatalog.Entities;
using MultiShop.Catatalog.Settings;

namespace MultiShop.Catatalog.Services.ProductServices {
    public class ProductService : IProductService {

        private readonly IMapper mapper;
        private readonly IMongoCollection<Product> _productCollection;

        public ProductService(IMapper mapper, IDatabaseSettings _databaseSettings) {
            var client=new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            this.mapper = mapper;   
        }   


        public async Task CreateProductAsync(CreateProductDto createProductDto) {
            var values = mapper.Map<Product>(createProductDto);
            await _productCollection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id) {
            await _productCollection.DeleteOneAsync(x=> x.ProductId == id); 
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync() {
            var values = await _productCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProductAsync(string id) {
            var values = await _productCollection.FindAsync(x=>x.ProductId == id);
            return mapper.Map<GetByIdProductDto>(values);
        }

        public async Task UpdateProductDtoAsync(UpdateProductDto updateProductDto) {
            var values = mapper.Map<Product>(updateProductDto);
            await _productCollection.FindOneAndReplaceAsync(x=> x.ProductId == updateProductDto.ProductId ,values);
        }
    }
}
