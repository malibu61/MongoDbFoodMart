using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.FeatureDto;
using MongoDbFoodMart.Services.Feature;

namespace MongoDbFoodMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {
        private readonly IFeatureService _FeatureService;

        public FeatureController(IFeatureService FeatureService)
        {
            _FeatureService = FeatureService;
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _FeatureService.CreateFeatureAsync(createFeatureDto);
            return RedirectToAction("FeatureList");
        }

        public async Task<IActionResult> FeatureList()
        {
            var values = await _FeatureService.GetAllFeatureAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _FeatureService.DeleteFeatureAsync(id);
            return RedirectToAction("FeatureList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            var values = await _FeatureService.GetByIdFeatureAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _FeatureService.UpdateFeatureDto(updateFeatureDto);
            return RedirectToAction("FeatureList");
        }

    }
}
