using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija.Controllers
{
    public class HomeController : Controller
    {
        AdventureWorksOBPEntities dataBase = new AdventureWorksOBPEntities();
        // GET: Home
        public ActionResult Index()
        {
            var model = dataBase.Kupacs;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = dataBase.Kupacs.Find(id).Racuns;
            return View(model);
        }

        public ActionResult GetStavke(int id)
        {
            var model = dataBase.Racuns.Find(id).Stavkas;
            return View(model);
        }
    }
}