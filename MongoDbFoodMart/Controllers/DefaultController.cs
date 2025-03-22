using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MongoDbFoodMart.Dtos.MailDto;
using MongoDbFoodMart.Services.Product;
using Newtonsoft.Json;

namespace MongoDbFoodMart.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult SendMail(SendMailDto model)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("FoodMartAdmin", "muhammedd1745@gmail.com");
            mimeMessage.From.Add(mailboxAddressFrom);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", model.ReceiverMail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = model.Subject;

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("muhammedd1745@gmail.com", "z i l b f p p v p c j z k f c f​");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return Redirect("/Default/Index");
        }

    }
}
