using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartialSnacks : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartialSnacks(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsByCategoryIdAsync("67d2a7b803312a539d646197");
            return View(values);
        }
    }
}
