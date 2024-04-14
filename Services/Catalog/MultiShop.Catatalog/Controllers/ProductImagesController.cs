using Microsoft.AspNetCore.Mvc;
using MultiShop.Catatalog.Dtos.ProductImageDtos;
using MultiShop.Catatalog.Services.ProductImageServices;

namespace MultiShop.Catatalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : Controller {

        private readonly IProductImageService productImageService;

        public ProductImagesController(IProductImageService ProductImageService) {
            this.productImageService = ProductImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList() {
            var values = await productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id) {
            var values = await productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto) {
            await productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("ProductImage added succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id) {
            await productImageService.DeleteProductImageAsync(id);
            return Ok("ProductImage deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto) {
            await productImageService.UpdateProductImageDtoAsync(updateProductImageDto);
            return Ok("ProductImage successfully updated.");
        }

    }
}
