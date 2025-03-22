using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Feature;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultDiscount2Partial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultDiscount2Partial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _featureService.Get2FeatureAsync();
            return View(values);
        }
    }
}
