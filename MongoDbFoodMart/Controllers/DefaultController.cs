using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;
using Newtonsoft.Json;

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

        public async Task<IActionResult> GetProductsByCategoryId(string id = "67bf680bf164ef0ac0d9b3b1")
        {
            var values = await _productService.GetProductsByCategoryIdAsync(id);
            return View(values);
        }


        public async Task<IActionResult> ProductsListByCategoryId(string id)
        {


            var values = await _productService.GetProductsByCategoryIdAsync(id);

            return PartialView(values);


        }
    }
}
