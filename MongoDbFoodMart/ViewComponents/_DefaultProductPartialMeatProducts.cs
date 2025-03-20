using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartialMeatProducts : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartialMeatProducts(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _productService.GetProductsByCategoryIdAsync("67d491100259da7797c6f171");
            return View(values);
        }
    }
}
