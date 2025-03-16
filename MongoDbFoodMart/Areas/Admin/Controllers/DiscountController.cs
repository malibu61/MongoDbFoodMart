using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.DiscountDto;
using MongoDbFoodMart.Services.Discount;

namespace MongoDbFoodMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DiscountController : Controller
    {
        private readonly IDiscountService _DiscountService;

        public DiscountController(IDiscountService DiscountService)
        {
            _DiscountService = DiscountService;
        }

        [HttpGet]
        public IActionResult CreateDiscount()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
        {
            await _DiscountService.CreateDiscountAsync(createDiscountDto);
            return RedirectToAction("DiscountList");
        }

        public async Task<IActionResult> DiscountList()
        {
            var values = await _DiscountService.GetAllDiscountAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteDiscount(string id)
        {
            await _DiscountService.DeleteDiscountAsync(id);
            return RedirectToAction("DiscountList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateDiscount(string id)
        {
            var values = await _DiscountService.GetByIdDiscountAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
        {
            await _DiscountService.UpdateDiscountDto(updateDiscountDto);
            return RedirectToAction("DiscountList");
        }

    }

}
