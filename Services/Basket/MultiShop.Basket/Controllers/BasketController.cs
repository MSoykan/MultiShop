using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Basket.Dtos;
using MultiShop.Basket.LoginServices;
using MultiShop.Basket.Services;

namespace MultiShop.Basket.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase {
        private readonly IBasketService basketService;
        private readonly ILoginService loginService;

        public BasketController(IBasketService basketService, ILoginService loginService) {
            this.basketService = basketService;
            this.loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail() {
            var user = User.Claims;
            var values = await basketService.GetBasket(loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basketTotalDto) {
            basketTotalDto.UserId = loginService.GetUserId;
            await basketService.SaveBasket(basketTotalDto);
            return Ok("Basket changes has been stored.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBasket() {
            await basketService.DeleteBasket(loginService.GetUserId);
            return Ok("Basket has been deleted.");
        }
    }
}
