using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers {
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase {
        private readonly IDiscountService discountService;

        public DiscountsController(IDiscountService discountService) {
            this.discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> DiscountCouponList() {
            var values = await discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id) {
            var values = await discountService.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCouponById(int id){
            await discountService.DeleteDiscountCouponAsync(id);
            return Ok("Coupon has been deleted succesfully. Id:"+ id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto) {
            await discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Coupon has been created succesfully. Coupon:\n"+ createCouponDto.ToString());
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto) {
            await discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Coupon with id: " + updateCouponDto.CouponId + " has been succesfully updated.");
        }
    }
}
