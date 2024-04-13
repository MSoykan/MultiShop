using Microsoft.AspNetCore.Mvc;
using MultiShop.Catatalog.Dtos.ProductDetailsDtos;
using MultiShop.Catatalog.Services.ProductDetailServices;

namespace MultiShop.Catatalog.Controllers {
    public class ProductDetailsController : Controller {

        private readonly IProductDetailService ProductDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService) {
            this.ProductDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList() {
            var values = await ProductDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id")]
        public async Task<IActionResult> GetProductDetailById(string id) {
            var values = ProductDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto) {
            await ProductDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail added succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id) {
            await ProductDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto) {
            await ProductDetailService.UpdateProductDetailDtoAsync(updateProductDetailDto);
            return Ok("ProductDetail successfully updated.");
        }

    }
}
