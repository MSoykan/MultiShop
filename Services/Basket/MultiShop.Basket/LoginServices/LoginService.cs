namespace MultiShop.Basket.LoginServices {
    public class LoginService : ILoginService {
        private readonly IHttpContextAccessor httpContextAccessor;

        public LoginService(IHttpContextAccessor contextAccessor) {
            httpContextAccessor = contextAccessor;
        }

        public string GetUserId => httpContextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
