using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartialMilkProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartialMilkProducts(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsByCategoryIdAsync("67bf680bf164ef0ac0d9b3b1");
            return View(values);
        }
    }
}
