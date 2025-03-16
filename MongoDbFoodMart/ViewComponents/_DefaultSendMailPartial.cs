using Microsoft.AspNetCore.Mvc;

namespace MongoDbFoodMart.ViewComponents
{
    public class _DefaultSendMailPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
