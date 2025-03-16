using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Discount;
using MongoDbFoodMart.Services.Feature;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultDiscountPartial : ViewComponent
    {
        private readonly IDiscountService _discountService;

        public _DefaultDiscountPartial(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _discountService.GetAllDiscountAsync();
            return View(values);
        }
    }
}
