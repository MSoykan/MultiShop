using Microsoft.AspNetCore.Mvc;
using MultiShop.Catatalog.Dtos.ProductImageDtos;
using MultiShop.Catatalog.Services.ProductImageServices;

namespace MultiShop.Catatalog.Controllers {
    public class ProductImagesController : Controller {

        private readonly IProductImageService ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService) {
            this.ProductImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList() {
            var values = await ProductImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id")]
        public async Task<IActionResult> GetProductImageById(string id) {
            var values = ProductImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto) {
            await ProductImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage added succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id) {
            await ProductImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto) {
            await ProductImageService.UpdateProductImageDtoAsync(updateProductImageDto);
            return Ok("ProductImage successfully updated.");
        }

    }
}
