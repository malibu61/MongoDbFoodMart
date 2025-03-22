using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Sale;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultBestSellingProductsPartial : ViewComponent
    {
        private readonly ISaleService _saleService;

        public _DefaultBestSellingProductsPartial(ISaleService saleService)
        {
            _saleService = saleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _saleService.Last6SaleAsync();
            return View(values);
        }
    }
}
