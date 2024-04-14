using Microsoft.AspNetCore.Mvc;
using MultiShop.Catatalog.Dtos.ProductDtos;
using MultiShop.Catatalog.Services.ProductServices;

namespace MultiShop.Catatalog.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller {
        private readonly IProductService productService;

        public ProductsController(IProductService ProductService) {
            this.productService = ProductService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList() {
            var values = await productService.GetAllProductAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id) {
            var values = await productService.GetByIdProductAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto) {
            await productService.CreateProductAsync(createProductDto);
            return Ok("Product added succesfully");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id) {
            await productService.DeleteProductAsync(id);
            return Ok("Product deleted succesfully");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto) {
            await productService.UpdateProductDtoAsync(updateProductDto);
            return Ok("Product successfully updated.");
        }

    }
}
