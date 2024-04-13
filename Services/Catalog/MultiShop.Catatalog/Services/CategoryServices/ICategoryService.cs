

using MultiShop.Catatalog.Dtos.CategoryDtos;

namespace MultiShop.Catatalog.Services.CategoryServices {
    public interface ICategoryService {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryDtoAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string id);
        Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
    }
}
