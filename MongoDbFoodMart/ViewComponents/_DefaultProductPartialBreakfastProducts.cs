using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartialBreakfastProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartialBreakfastProducts(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsByCategoryIdAsync("67d2a7c103312a539d646198");
            return View(values);
        }
    }
}
