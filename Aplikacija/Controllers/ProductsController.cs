using Aplikacija.App_Start;
using Aplikacija.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aplikacija.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        
        // GET: Products
        public ActionResult Index()
        {
            ViewBag.productsCount = Repo.GetProductsCount();
            return View();
        }

        [HttpGet]
        public ActionResult GetProducts()
        {
            return Json(Repo.GetProizvodi(), JsonRequestBehavior.AllowGet);
       
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            var proizvod = Repo.GetProizvod(id);
            ViewBag.potkategorije = Repo.GetPotkategorije();
            return View(proizvod);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Proizvod p)
        {
           
            if (ModelState.IsValid)
            {
                Repo.UpdateProizvod(p);
                return RedirectToAction("Index");
            }
            else
            {
                return View(p);
            }
        }

        public ActionResult DeleteProduct(int id)
        {
            
             Repo.DeleteProizvod(id);
             return RedirectToAction("Index");
            
        }

        [HttpGet]
        public ActionResult CreatePr()
        {
            ViewBag.potks = Repo.GetPotks();
            return View();
        }

        [HttpPost]
        public ActionResult CreatePr(Proizvod p)
        {
            if (ModelState.IsValid)
            {
                Repo.CreateProizvod(p);
                return View("Confirmation_3rd", p);
            }
            else
            {
                return View(p);
            }
        }
    }
}