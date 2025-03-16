using Microsoft.AspNetCore.Mvc;
using MongoDbFoodMart.Services.Category;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultCategoryPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultCategoryPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
