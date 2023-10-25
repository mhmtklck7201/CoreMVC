using LastResume.Business.Abstract;
using LastResume.Data.Abstract;
using LastResume.Entity.Models;
using LastResumeAdmin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LastResumeAdmin.Controllers
{
    [AutoValidateAntiforgeryToken] //her postta csrf ataklarının önüne geçer 

    public class AccountController : Controller
    {
        private IBlogRepository _blogRepo;
        private UserManager<User> _usermanager { get; set; }
        private SignInManager<User> _signInManager; //cookie yönetimi
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IBlogRepository blogRepo)
        {
            this._usermanager = userManager;
            _signInManager = signInManager;
            _blogRepo = blogRepo;

        }
      

        [HttpGet]
        public async Task<IActionResult> Login(string ReturnUrl = null) //kullanıcıyı loginden önceyi sayfaya yönlendirmemiz gerek login olduktan sonra bu yüzden return urli alıyoruz burada
        {
            return View(new LoginModel
            {
                ReturnUrl = ReturnUrl //bunu daha sonra input hiddenda tutarız (yanlis bir şeyler girildiğinde tekrar post metodundan geleceği için return url boş gelmesin)
            });


        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _usermanager.FindByEmailAsync(model.Email); //username var mı diye control

            if (user == null)
            {
                ModelState.AddModelError("", "Bu email adresi ile daha önce hesap oluşturulmamış");
                return View(model);
            }

            //if (!await _usermanager.IsEmailConfirmedAsync(user))
            //{

            //    ModelState.AddModelError("", "Lütfen hesabınıza gelen maili onaylayınız!");
            //    return View(model);
            //}



            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false); //4.parametre 20 dk lık seesion süresi tanımlansın mı ,5.parametre hesap kilitlesin mi

            if (result.Succeeded)
            {
                return Redirect("~/Account/DashBoard"); //null sa home pageye git dedik.
                                                        //   return Redirect("/Account/DashBoard");
                                                        //  return  RedirectToAction("DashBoard", "Account");
            }
            ModelState.AddModelError("", "Girilen email veya şifre yanlış");

            return View(model);
        }
        [AllowAnonymous]

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = new User()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };
            var result = await _usermanager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {

                //Eğer mail dorulama yapmak istersen bu kısımda bir token oluştur.    
                //var code = await _usermanager.GenerateEmailConfirmationTokenAsync(user);
                //var url = Url.Action("ConfirmedEmail", "Account", new
                //{  //bu kısım url oluşturuyor.
                //    userId = user.Id,
                //    token = code
                //});
                //  await _emailSender.SendEmailAsync(model.Email, "Hesabınız onaylayınız", $"Lütfen email hesabınızı onaylanmak için linke <a href='https://localhost:44317{url}'>tıklayınız</a> ");
                return RedirectToAction("Login", "Account");
            }

            ModelState.AddModelError("Password", "Bilinmeyen bir hata oldu");//Burdan hata ekleyebilirsin(Başka bir hata olduysa böyle gönderebilirsin)
            return View();

        }
        [Authorize]
        [HttpGet]
        public IActionResult DashBoard()
        {


            return View();
        }

        public PartialViewResult GetAllBlogs()
        {
            var blog = _blogRepo.getAll();
            return PartialView("~/Views/Account/GetAllBlogs", blog);


        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

        public ActionResult DeleteBlog(int id)
        {
            _blogRepo.Delete(_blogRepo.getById(id));
            return RedirectToAction(nameof(DashBoard));
        }

        [HttpGet]
        public ActionResult UpdateBlog(int id)
        {
            var card = _blogRepo.getById(id);

            return View(card);// RedirectToAction("UpdateBlog", "Account", card);
       }
 
        [HttpPost]
        public ActionResult UpdateBlog(BlogCard card)

        {
            _blogRepo.Update(card);
            return View(card);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DashBoard(BlogCard blog)
        {
            if (ModelState.IsValid)
            {
                var entity = new BlogCard()
                {
                    BlogLink = blog.BlogLink,
                    BlogKeyWords = blog.BlogKeyWords,
                    BlogLongDesc = blog.BlogLongDesc,
                    BlogShortDesc = blog.BlogShortDesc,
                    BlogTitle = blog.BlogTitle

                };
                //  _blogRepo.Delete(entity);
                _blogRepo.Create(entity);
                ModelState.Clear();

            }
            //BlogCategory category = new BlogCategory() { CategoryDescription = "Html", Id = 2, CategoryName = "HTML" };
            //category.BlogCards = new List<BlogCard> { blog};
            //blog.BlogCategory = category;

            //blog.Id = 5;

            return View(blog);
        }
        [AllowAnonymous]

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ForgotPasswordAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return View();
            }
            var user = await _usermanager.FindByEmailAsync(email);
            if (user == null)
            {
                return View();
            }
            var code = await _usermanager.GeneratePasswordResetTokenAsync(user); //reset token 


            return RedirectToAction("ResetPassword", "Account", new
            {  //bu kısım url oluşturuyor.
                userId = user.Id,
                token = code
            });
            //   await _emailSender.SendEmailAsync(email, "Reset password", $"Lütfen parolanızı yenilemek için linke <a href='https://localhost:44317{url}'>tıklayınız</a> ");
            //return View();
        }
        [HttpGet]
        public IActionResult ResetPassword(string userId, string token) //hidden olarak saklayacağız.
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var model = new ResetPasswordModel()
            { Token = token };

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ResetPasswordAsync(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _usermanager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return RedirectToAction("Home", "Index");
            }

            var result = await _usermanager.ResetPasswordAsync(user, model.Token, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Login", "Account");

            }

            return View(model);
        }
    }
}
