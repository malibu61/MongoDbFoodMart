using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultProductPartial : ViewComponent
    {
        private readonly IProductService _productService;

        public _DefaultProductPartial(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsByCategoryIdAsync(id);
            return View(values);
        }
    }
}
