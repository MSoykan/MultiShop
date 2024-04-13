using Microsoft.AspNetCore.Mvc;

namespace MultiShop.Catatalog.Controllers {
    public class ProductsController : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
