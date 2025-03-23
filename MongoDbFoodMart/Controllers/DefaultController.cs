using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MongoDbFoodMart.Dtos.MailDto;
using MongoDbFoodMart.Services.Product;
using Newtonsoft.Json;
using System.Net.Mail;

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


            mimeMessage.Subject = "Bültenimize Hoşgeldin!";

            var userName = model.Name;  // Kullanıcının adı model.Name'den alınıyor

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = $@"
    <html>
    <head>
        <style>
            body {{ font-family: Arial, sans-serif; background-color: #f4f4f4; margin: 0; padding: 0; }}
            .container {{ width: 100%; max-width: 600px; margin: 0 auto; padding: 20px; background-color: #ffffff; border-radius: 8px; box-shadow: 0 2px 10px rgba(0, 0, 0, 0.1); }}
            h1 {{ color: #4CAF50; text-align: center; }}
            .alert {{ padding: 15px; margin: 10px 0; border-radius: 5px; font-size: 16px; color: white; }}
            .alert.hosgeldin {{ background-color: #007bff; }}
            .alert.indirim {{ background-color: #ff5722; }}
            .alert.alisveris {{ background-color: #28a745; }}
            .alert strong {{ font-weight: bold; }}
            .footer {{ text-align: center; font-size: 12px; color: #888; margin-top: 20px; }}
            .button {{ display: inline-block; padding: 10px 20px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px; font-size: 16px; margin-top: 20px; text-align: center; }}
        </style>
    </head>
    <body>
        <div class='container'>
            <h1>Hoşgeldin, {userName}!</h1>  <!-- Dinamik olarak ad ekleniyor -->

            <!-- Hoşgeldin Mesajı -->
            <div class='alert hosgeldin'>
                <strong>Hoşgeldin, {userName}!</strong> Üyeliğin başarıyla oluşturuldu. Artık sen de bizimle alışveriş yapabilirsin.
            </div>

            <!-- İndirim Mesajı -->
            <div class='alert indirim'>
                <strong>Özel İndirim!</strong> İlk alışverişine özel %20 indirim seni bekliyor. Şimdi alışveriş yap!
            </div>

            <!-- Alışverişe Başla -->
            <div class='alert alisveris'>
                <strong>Alışverişe Başla!</strong> Sadece birkaç tıklama ile ürünlerini keşfetmeye başlayabilirsin. Alışverişe başlamak için hemen tıkla!
                <a href='https://www.ornek.com/alisveris' class='button'>Alışverişe Başla</a>
            </div>

            <div class='footer'>
                Bu e-posta sistem tarafından otomatik olarak gönderilmiştir. Yanıt vermeyin.
            </div>
        </div>
    </body>
    </html>"
            };



            //bodyBuilder.TextBody = model.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            //mimeMessage.Subject = model.Subject;

            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("muhammedd1745@gmail.com", "z i l b f p p v p c j z k f c f​");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return Redirect("/Default/Index");
        }

    }
}
