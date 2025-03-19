using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Category;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartial1 : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartial1(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsByCategoryIdAsync("67bf6803f164ef0ac0d9b3b0");
            return View(values);
        }
    }
}
