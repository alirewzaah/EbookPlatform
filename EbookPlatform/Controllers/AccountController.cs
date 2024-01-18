using EbookPlatform.Core.Service.Interface;
using EbookPlatform.Core.ViewModels;
using EbookPlatform.Core.ExtentionMethods;
using Microsoft.AspNetCore.Mvc;
using static Kalamarket.Core.ExtentionMethod.RenderEmail;
using EbookPlatform.Core.Service;
using Kalamarket.Core.ExtentionMethod;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace EbookPlatform.Controllers
{
    public class AccountController : Controller
    {

        private IUserService _UserService;
        private IViewRenderService _viewRenderService;
        public AccountController(IUserService userService , IViewRenderService viewRenderService)
        {
                _UserService = userService;     
            _viewRenderService = viewRenderService;
        }



        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Logout");
            }
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterViewmodel viewmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewmodel);
            }
            if (_UserService.DoesExist(viewmodel.email,0))
            {
                ModelState.AddModelError("email", "karbari ba in email ghablan sabt nam karde ast ......");
                return View(viewmodel);
            }
            User user = new User
            {
                DateCreated = DateTime.Now,
                isActive = false,
                isDeleted=false,
                password = viewmodel.password.EncodePasswordMd5(),
                UserName = viewmodel.accountname,
                email=viewmodel.email,
                ActiveCode=GenerateCode.GuidCode()
                
            };

            int userid = _UserService.AddUser(user);
            if (userid>0)
            {
                var renderView = _viewRenderService.RenderToStringAsync("_ActiveEmail", user);
               bool ok =  sendEmail.Send(user.email, "Email Activation Form From EbookPlatform", renderView);
                return View("Welcome",user.email);
            }
            return View(viewmodel);
        }



        [Route("Account/ActiveAccount/{userid}/{Code}")]
        public IActionResult ActiveAccount(int userid, string Code)
        {
            User user = _UserService.Finduser(userid, Code);

            if (user == null)
            {
                return NotFound();
            }
            user.isActive = true;
            user.ActiveCode = GenerateCode.GuidCode();
            _UserService.UpdateUser(user);
            return RedirectToAction("Index", "Home");
        }


        public IActionResult ForgotPassword()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View("Logout");
            }
            return View();
        }


        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewmodel model)
        {
            User user = _UserService.FindUserbuyeEmail(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربری با این مشخصات ی افت نشد .");
                return View(model);
            }

            var renderView = _viewRenderService.RenderToStringAsync("_RecoveryPassword", user);
            sendEmail.Send(user.email, "باز یابی کلمه عبور", renderView);
            return View("RecoveryMassage", user.email);
        }


        [Route("Account/Recovery/{userid}/{Code}")]
        public IActionResult Recovery(int userid, string Code)
        {
            User user = _UserService.Finduser(userid, Code);

            if (user != null)
            {

                ForgotPasswordViewmodel viewmodel = new ForgotPasswordViewmodel
                {
                    userid = user.userID,
                    Email = user.email,
                };
                return View("Recovery", viewmodel);
            }
            //    ModelState.AddModelError("", "token expired");
            bool tmp = false;
            TempData["Result"] = tmp ? "true" : "false";
            return View();
        }


        [HttpPost]
        [Route("Account/Recovery/{userid}/{Code}")]
        public IActionResult Recovery(ForgotPasswordViewmodel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Recovery", model);
            }
            User user = _UserService.FindUserbuyeEmail(model.Email);
            if (user != null)
            {
                user.ActiveCode = GenerateCode.GuidCode();
                user.password = model.Password.EncodePasswordMd5();
            };

            bool updateuser = _UserService.UpdateUser(user);
            TempData["Result"] = updateuser ? "true" : "false";
            return View("ForgotPassword");
        }



        public IActionResult Login()
        {
            if(User.Identity.IsAuthenticated) 
            {

                return View("Logout");
            }
            return View();

        }


        [HttpPost]
        public IActionResult Login(LoginViewmodel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            User user = _UserService.LoginUser(model.email, model.Password.EncodePasswordMd5());

            if (user != null)
            {
                if (user.isActive)
                {
                    var claim = new List<Claim>
                    {
                        new Claim("userid",user.userID.ToString()),
                        new Claim("useraccount",user.UserName),
                        new Claim("useremail",user.email),
                    };
                    var option = new AuthenticationProperties
                    {
                        IsPersistent = model.Rememberme,
                    };
                    HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claim, "Coockies")), option);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Rememberme", "حساب کاربری شما فعال نمی باشد ");
                    return View(model);
                }
            }
            ModelState.AddModelError("Rememberme", "کاربری با این مشخصات یافت نشد.");
            return View(model);
        }


        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }


















    }
}
