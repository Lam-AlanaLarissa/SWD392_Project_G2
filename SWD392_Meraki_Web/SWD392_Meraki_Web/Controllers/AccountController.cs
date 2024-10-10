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
            // Lấy thông tin UserId từ claims
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (userId == null)
            {
                TempData["Msg"] = "User is not logged in!";
                return RedirectToAction("Login", "Account");  // Hoặc chuyển hướng đến login nếu không có UserId
            }

            // Lấy thông tin người dùng từ cơ sở dữ liệu
            User user = _accountRepository.GetUserById(userId);

            if (user == null)
            {
                TempData["Msg"] = "User not found!";
                return View();
            }

            // Trả về view với dữ liệu người dùng
            return View(user);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, User updatedUser)
        {
            if (ModelState.IsValid)
            {
                var user = _accountRepository.GetUserById(id);
                if (user == null)
                {
                    TempData["Msg"] = "Failure!";
                }

                // Only update the allowed fields
                user.Username = updatedUser.Username;
                user.Gender = updatedUser.Gender;
                user.Address = updatedUser.Address;
                user.Birthday = updatedUser.Birthday;

                _accountRepository.UpdateUser(user);
                return RedirectToAction("ViewProfile", new { id = user.UserId });
            }

            return View(updatedUser);
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}