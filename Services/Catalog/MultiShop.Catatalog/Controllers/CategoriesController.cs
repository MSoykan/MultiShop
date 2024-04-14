using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catatalog.Dtos.CategoryDtos;
using MultiShop.Catatalog.Services.CategoryServices;

namespace MultiShop.Catatalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase {

        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService) {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList() {
            var values = await categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id) {
            var values = await categoryService.GetByIdCategoryAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto) {
            await categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Category added succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id) {
            await categoryService.DeleteCategoryAsync(id);
            return Ok("Category deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto) {
            await categoryService.UpdateCategoryDtoAsync(updateCategoryDto);
            return Ok("Category successfully updated.");
        }

    }
}
