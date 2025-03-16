using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Dtos.ProductDto;
using MongoDbFoodMart.Services.Product;

namespace MongoDbFoodMart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService ProductService)
        {
            _productService = ProductService;
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("ProductList");
        }

        public async Task<IActionResult> ProductList()
        {
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("ProductList");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            var values = await _productService.GetByIdProductAsync(id);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductDto(updateProductDto);
            return RedirectToAction("ProductList");
        }

    }

}
