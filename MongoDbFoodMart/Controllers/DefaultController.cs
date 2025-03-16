using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetProductsByCategoryId(string id= "67bf6803f164ef0ac0d9b3b0")
        {
            var values = await _productService.GetProductsByCategoryIdAsync(id);
            return PartialView("_DefaultProductPartial", values);
        }
    }
}
