using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Feature;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultFeature_DiscountPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;

        public _DefaultFeature_DiscountPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
