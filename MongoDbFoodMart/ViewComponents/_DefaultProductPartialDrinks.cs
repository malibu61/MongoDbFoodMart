using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartialDrinks : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartialDrinks(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsByCategoryIdAsync("67d2a7b003312a539d646196");
            return View(values);
        }
    }
}
