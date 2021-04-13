using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RazorMvc.Controllers
{
    public class InternshipController : Controller
    {
        // GET: InternshipController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InternshipController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InternshipController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InternshipController/Create
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

        // GET: InternshipController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InternshipController/Edit/5
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

        // GET: InternshipController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InternshipController/Delete/5
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
