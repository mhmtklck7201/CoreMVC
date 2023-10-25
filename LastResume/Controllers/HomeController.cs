using LastResume.Models;
using LastResume.Services;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LastResume.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private LanguageService _localization;
        public HomeController(ILogger<HomeController> logger,   LanguageService localization)
        {
            _logger = logger;
            _localization = localization;
        }

        public IActionResult Index()
        {
            ViewBag.Welcome = _localization.Getkey("Welcome").Value;
            var currentCulture = Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }
        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), new CookieOptions()
                {
                    Expires = DateTimeOffset.UtcNow.AddYears(1)
                });
            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult About()
        {
            DataContext dataContext = new DataContext();
            var Info = dataContext.GetUserInfo();
            return View("About", Info);
        }
        public IActionResult Resume()
        {
            return View("Resume");
        }
        public IActionResult Services()
        {
            return View("Services");
        }
        public IActionResult Portfolio()
        {
            DataContext dataContext = new DataContext();
            var data = dataContext.GetPortfolios();
            return View("Portfolio", data);
        }
        public IActionResult PortfolioDetails(int id)
        {
            DataContext dataContext = new DataContext();
            var data = dataContext.GetPortfolioDetail(id);


            return View("PortfolioDetails", data);
        }
        public IActionResult Contact()
        {
            ViewBag.IsSuccess = false;
            return View();
        }

        //[HttpGet]
        //public async Task<IActionResult> ListBlog()
        //{

        //}
        static void NEVER_EAT_POISON_Disable_CertificateValidation()
        {
            // Disabling certificate validation can expose you to a man-in-the-middle attack
            // which may allow your encrypted message to be read by an attacker
            // https://stackoverflow.com/a/14907718/740639
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (
                    object s,
                    X509Certificate certificate,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
                {
                    return true;
                };
        }
        [HttpPost]
        public IActionResult Contact(Mail mail)
        {



            if (ModelState.IsValid)
            {

                /*  MailMessage mesaj = new MailMessage();
                  mesaj.From = new MailAddress(mail.MailFrom) ; ;
                  mesaj.To.Add("mhmtklck7201@gmail.com");
                  mesaj.Subject = mail.MailSubject;
                  mesaj.Body =mail.MailMessage;

                  using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                  {
                      smtp.Credentials = new NetworkCredential("mhmtklck7201@gmail.com", "Mhmt.0102");
                      smtp.EnableSsl = true;
                      smtp.Send(mesaj);
                  }

                  object userState = mesaj;*/
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
    (sender, certificate, chain, errors) =>
    {
        return true;
    };
                    // MailMessage mm = new MailMessage("mhmtklck7201@mehmetkalcik.com.tr", "mhmtklck7201@gmail.com") //hosting=>gmaile gönderiyor
                    // MailMessage mm = new MailMessage("mhmtklck7201@mehmetkalcik.com.tr", "mhmtklck7201@mehmetkalcik.com.tr") //hosting=>hostinge gönderiyor
                    MailMessage mm = new MailMessage("mhmtklck7201@mehmetkalcik.com.tr", "mhmtklck7201@mehmetkalcik.com.tr")
                    {
                        Subject = mail.MailSubject,
                        Body = mail.MailFrom+"'dan gelen mail:"+ mail.MailMessage,
                        IsBodyHtml = true
                    };
                    SmtpClient smtp = new SmtpClient
                    {
                        Host = "mail.mehmetkalcik.com.tr",
                        EnableSsl = true
                    };
                    NetworkCredential NetworkCred = new NetworkCredential
                    {
                        UserName = "mhmtklck7201@mehmetkalcik.com.tr",
                        Password = "Mhmt.0102"
                    };
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                    ViewBag.IsSuccess = true;

                    /*  string to = "mhmtklck7201@gmail.com"; //To address    
                      string from = mail.MailFrom; //From address    
                      MailMessage message = new MailMessage(from, to);

                      string mailbody = mail.MailMessage;
                      message.Subject = mail.MailSubject;
                      message.Body = mailbody;
                      message.BodyEncoding = Encoding.UTF8;
                      message.IsBodyHtml = true;
                      SmtpClient client = new SmtpClient("win4.wlsrv.com", 465);
                      client.EnableSsl = true;
                      var basicCredential1 = new System.Net.NetworkCredential("mhmtklck7201@mehmetkalcik.com.tr", "*********");          
                      client.Credentials = basicCredential1;
                      //NEVER_EAT_POISON_Disable_CertificateValidation();
                      client.Send(message);
                      ViewBag.IsSuccess = true; */
                    //  System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;

                }
                catch (Exception ex)
                {
                    ViewBag.IsSuccess = false;
                }
                //if success viebag.IsSuccess=true 
            }
            else ViewBag.IsSuccess = false;




            return View(mail);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}