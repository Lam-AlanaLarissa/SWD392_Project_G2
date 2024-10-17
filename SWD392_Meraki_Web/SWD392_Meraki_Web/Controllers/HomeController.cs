using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWD392_Meraki_Web.DatabaseConnection;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Models.DTO;
using System.Diagnostics;

namespace SWD392_Meraki_Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly BookingBadmintonContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new BookingBadmintonContext();
        }
        
        public IActionResult Index()
        {
            var courts = _context.Courts.ToList();
            return View(courts);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
