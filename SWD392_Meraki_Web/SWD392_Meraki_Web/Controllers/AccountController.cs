using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using SWD392_Meraki_Web.Repositories.Interface;

namespace SWD392_Meraki_Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }


        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Edit()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                TempData["Msg"] = "User is not logged in!";
                return RedirectToAction("Login", "Account");
            }
            User user = _accountRepository.GetUserById(userId);

            if (user == null)
            {
                TempData["Msg"] = "User not found!";
                return View();
            }
            return View(user);
        }
        [HttpPost]
        public IActionResult Edit(User updatedUser)
        {
            ModelState.Remove("UserId");
            ModelState.Remove("Password");
            if (!ModelState.IsValid)
            {
                return View(updatedUser);
            }
            User oldUser = _accountRepository.GetUserByEmail(updatedUser.Email);
            if (oldUser == null)
            {
                ModelState.AddModelError("", "Người dùng không tồn tại.");
                return View(updatedUser);
            }   
            oldUser.Username = updatedUser.Username;
            oldUser.PhoneNumber = updatedUser.PhoneNumber;
            oldUser.Birthday = updatedUser.Birthday; 
            oldUser.Address = updatedUser.Address;

            bool updateSuccess = _accountRepository.UpdateUser(oldUser);
            if (updateSuccess)
            {
                TempData["Message"] = "Cập nhật thông tin cá nhân thành công!";
            }
            else
            {
                TempData["Message"] = "Cập nhật thông tin thất bại, vui lòng thử lại!";
            }

            return View(updatedUser);
        }

        /*  public IActionResult GoogleLogin(string? returnUrl)
            {
                string? url = Url.Action("googleresponse", "account", new { returnUrl }, protocol: Request.Scheme);
                var properties = new AuthenticationProperties { RedirectUri = url };
                return Challenge(properties, GoogleDefaults.AuthenticationScheme);
            }

          public async Task<IActionResult> GoogleResponse(string? returnUrl)
          {
              await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
              if (string.IsNullOrEmpty(returnUrl))
              {
                  return Redirect("/");
              }
              return Redirect(returnUrl);
          }*/
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User obj, string? returnUrl)
        {
            User? user = _accountRepository.GetUser(obj);
            if (user is null)
            {
                ModelState.AddModelError("Error", "Login Failed");
                return View(obj);
            }
            List<Claim> list = new List<Claim> {
    new Claim(ClaimTypes.NameIdentifier, user.UserId),
    new Claim(ClaimTypes.Name, user.Username),
    new Claim(ClaimTypes.Email, user.Email ?? ""),
    // Các claims tùy chỉnh phải có tên tùy chỉnh
    new Claim("Gender", user.Gender?.ToString() ?? ""),
    new Claim("PhoneNumber", user.PhoneNumber ?? ""),
    new Claim("Address", user.Address ?? ""),
    new Claim("Birthday", user.Birthday?.ToString() ?? ""),
};

            var principal = new ClaimsPrincipal(new ClaimsIdentity(list, CookieAuthenticationDefaults.AuthenticationScheme));
            await HttpContext.SignInAsync(principal);
            if (string.IsNullOrEmpty(returnUrl))
            {
                return Redirect("/");
            }
            return Redirect(returnUrl);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // Đăng xuất người dùng (SignOut)
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Chuyển hướng người dùng về trang đăng nhập
            return RedirectToAction("Login", "Account");
        }
    }
}