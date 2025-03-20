using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.ProductDto;
using MongoDbFoodMart.Dtos.SaleDto;
using MongoDbFoodMart.Services.Sale;

namespace MongoDbFoodMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult CreateSale()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSale(CreateSaleDto createSaleDto)
        {
            await _saleService.CreateSaleAsync(createSaleDto);
            return RedirectToAction("SaleList");
        }

        public async Task<IActionResult> SaleList()
        {
            var values = await _saleService.GetAllSaleAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteSale(string id)
        {
            await _saleService.DeleteSaleAsync(id);
            return RedirectToAction("SaleList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateSale(string id)
        {
            var values = await _saleService.GetByIdSaleAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSale(UpdateSaleDto updateSaleDto)
        {
            await _saleService.UpdateSaleDto(updateSaleDto);
            return RedirectToAction("SaleList");
        }
    }
}
