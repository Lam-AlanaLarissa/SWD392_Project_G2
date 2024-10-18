using Microsoft.AspNetCore.Mvc;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories.Interface;

namespace SWD392_Meraki_Web.Controllers
{
    public class CheckInController : Controller
    {
        private readonly IUserRepository _userRepository;

        public CheckInController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult CheckIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CheckIn(CheckIn checkIn)
        {
            if (ModelState.IsValid)
            {
                await _userRepository.CheckInUserAsync(checkIn);
                return RedirectToAction("Success");
            }
            return View(checkIn);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
