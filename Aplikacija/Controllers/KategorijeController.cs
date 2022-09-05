using Aplikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija.Controllers
{
    [Authorize]
    public class KategorijeController : Controller
    {
        // GET: Kategorije
        public ActionResult Index()
        {
            ViewBag.katCount = Repo.GetKatCount();
            return View(Repo.GetKategorije());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var kat = Repo.GetKategorija(id);

            return View(kat);
        }

        [HttpPost]
        public ActionResult Edit(Kategorija k)
        {
            if (ModelState.IsValid)
            {
                Repo.UpdateKategorija(k);
                return RedirectToAction("Index");
            }
            else
            {
                return View(k);
            }
        }

        
        public ActionResult DeleteKat(int id)
        {
            try
            {
                Repo.DeleteKategorija(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Category successfully deleted!");

            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Category unsuccessfully deleted!");
            }
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Kategorija k)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateKategorija(k);
                return View("Confirmation", k);
            }
            else
            {
                return View(k);
            }
        }
    }
}