using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catatalog.Dtos.ProductDetailsDtos;
using MultiShop.Catatalog.Services.ProductDetailServices;

namespace MultiShop.Catatalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : Controller {

        private readonly IProductDetailService productDetailService;

        public ProductDetailsController(IProductDetailService ProductDetailService) {
            this.productDetailService = ProductDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList() {
            var values = await productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id) {
            var values = await productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto) {
            await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("ProductDetail added succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id) {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("ProductDetail deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto) {
            await productDetailService.UpdateProductDetailDtoAsync(updateProductDetailDto);
            return Ok("ProductDetail successfully updated.");
        }

    }
}
