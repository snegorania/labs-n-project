using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SensorApp.Controllers
{
    public class IndicationController : Controller
    {
        // GET: IndicationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: IndicationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: IndicationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IndicationController/Create
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

        // GET: IndicationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: IndicationController/Edit/5
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

        // GET: IndicationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: IndicationController/Delete/5
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
