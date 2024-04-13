using MultiShop.Catatalog.Dtos.ProductDtos;

namespace MultiShop.Catatalog.Services.ProductServices {
    public interface IProductService {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductDtoAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProductAsync(string id);

    }
}
