using Microsoft.AspNetCore.Mvc;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultHeadPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
