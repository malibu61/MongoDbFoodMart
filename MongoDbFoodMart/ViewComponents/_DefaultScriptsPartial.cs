using Microsoft.AspNetCore.Mvc;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultScriptsPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
