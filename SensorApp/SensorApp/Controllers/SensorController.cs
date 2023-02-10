using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SensorApp.Controllers
{
    public class SensorController : Controller
    {
        // GET: SensorController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SensorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SensorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SensorController/Create
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

        // GET: SensorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SensorController/Edit/5
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

        // GET: SensorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SensorController/Delete/5
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
