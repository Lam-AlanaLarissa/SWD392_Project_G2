using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392_Meraki_Web.Models;
using SWD392_Meraki_Web.Repositories;
using SWD392_Meraki_Web.Repositories.Interface;

namespace SWD392_Meraki_Web.Controllers
{
    public class CourtController : Controller
    {
        private readonly ICourtRepository _courtRepository;
        public CourtController(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }
        // GET: CourtController
        public ActionResult Index()
        {
            var courts = _courtRepository.GetCourts();

            return View(courts);
        }
        // GET: CourtController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CourtController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourtController/Create
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

        // GET: CourtController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourtController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        [HttpPost]
        public IActionResult DeleteCourt(string id)
        {
            // Kiểm tra nếu ID không hợp lệ
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("ID cannot be null or empty.");
            }

            // Gọi phương thức xóa từ repository
            int ret = _courtRepository.DeleteCourt(id);
            if (ret > 0)
            {
                TempData["Message"] = "Xoá thành công!";
                return RedirectToAction("Index"); // Chuyển hướng về danh sách
            }

            return RedirectToAction("Error"); // Chuyển hướng đến trang lỗi
        }
    }
}
