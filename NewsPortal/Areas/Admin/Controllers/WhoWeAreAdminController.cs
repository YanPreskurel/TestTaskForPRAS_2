using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsPortal.Areas.Admin.Controllers
{
    public class WhoWeAreAdminController : Controller
    {
        // GET: WhoWeAreAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WhoWeAreAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WhoWeAreAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WhoWeAreAdminController/Create
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

        // GET: WhoWeAreAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WhoWeAreAdminController/Edit/5
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

        // GET: WhoWeAreAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WhoWeAreAdminController/Delete/5
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
