using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NewsPortal.Areas.Admin.Controllers
{
    public class CaseAdminController : Controller
    {
        // GET: CaseAdminController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CaseAdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CaseAdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CaseAdminController/Create
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

        // GET: CaseAdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CaseAdminController/Edit/5
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

        // GET: CaseAdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CaseAdminController/Delete/5
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
