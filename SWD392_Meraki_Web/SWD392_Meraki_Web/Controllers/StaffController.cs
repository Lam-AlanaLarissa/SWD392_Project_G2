using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWD392_Meraki_Web.Repositories.Interface;

namespace SWD392_Meraki_Web.Controllers
{
    public class StaffController : Controller
    {
        private readonly ICourtRepository _courtRepository;
        public StaffController(ICourtRepository courtRepository)
        {
            _courtRepository = courtRepository;
        }
        // GET: StaffController
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewCourt()
        {
            var courts = _courtRepository.GetCourtForStaff();
            return View(courts);
        }
        [HttpPost]
        public IActionResult CheckIn(string id)
        {
            int ret = _courtRepository.CheckIn(id);
            if (ret > 0)
            {
                TempData["Message"] = "Cập nhật thành công!";
                return RedirectToAction("ViewCourt");
            }
            TempData["Message"] = "Đã Checkin!";
            return RedirectToAction("ViewCourt");
        }
        [HttpPost]
        public IActionResult CheckOut(string id)
        {
            int ret = _courtRepository.CheckOut(id);
            if (ret > 0)
            {
                TempData["Message"] = "Cập nhật thành công!";
                return RedirectToAction("ViewCourt");
            }
            TempData["Message"] = "Đã Checkout!";
            return RedirectToAction("ViewCourt");
        }


        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffController/Create
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

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StaffController/Edit/5
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

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StaffController/Delete/5
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
    }
}
