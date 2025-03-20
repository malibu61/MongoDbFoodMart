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

    }
}
