using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SWD392_Meraki_Web.Controllers
{
    public class RevenueController : Controller
    {
        // GET: RevenueController
        public ActionResult Index()
        {
            return View();
        }

        // GET: RevenueController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RevenueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RevenueController/Create
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

        // GET: RevenueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RevenueController/Edit/5
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

        // GET: RevenueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RevenueController/Delete/5
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
