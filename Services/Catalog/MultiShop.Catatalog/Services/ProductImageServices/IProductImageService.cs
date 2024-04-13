using MultiShop.Catatalog.Dtos.ProductImageDtos;

namespace MultiShop.Catatalog.Services.ProductImageServices {
    public interface IProductImageService {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageDtoAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImageAsync(string id);
    }
}
