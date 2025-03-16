using Microsoft.AspNetCore.Mvc;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultDiscount2Partial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
