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
    public class PotkategorijeController : Controller
    {
        // GET: Potkategorije
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.potkCount = Repo.GetPotkCount();
            return View(Repo.GetPotkategorije());
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var potk = Repo.GetPotkategorija(id);
            ViewBag.kategorije = Repo.GetKategorije();

            return View(potk);
        }

        [HttpPost]
        public ActionResult Edit(Potkategorija p)
        {
            if (ModelState.IsValid)
            {
                Repo.UpdatePotkategorija(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult Remove(int id)
        {
            try
            {
                Repo.DeletePotkategorija(id);
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Subcategory successfully deleted!");
                
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Subcategory unsuccessfully deleted!");
            }
            
            
        }


        [HttpGet]
        public ActionResult CreateP()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateP(Potkategorija p)
        {
            if (ModelState.IsValid)
            {
                Repo.CreatePotkategorija(p);
                return View("Confirmation_2nd", p);
            }
            else
            {
                return View(p);
            }
        }
    }
}