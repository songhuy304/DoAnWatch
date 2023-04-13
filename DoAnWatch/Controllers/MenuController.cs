using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuLeft()
        {
            var items = db.Products.Where(x=>x.IsHot).Take(3).ToList();
            return PartialView("MenuLeft", items);
        }

        public ActionResult MenuProductCategory()
        {
            var items = db.ProductCategogies.ToList();
            return PartialView("MenuProductCategory", items);
        }
        public ActionResult MenuArrivals()
        {
            var items = db.ProductCategogies.ToList();
            return PartialView("MenuArrivals", items);
        }
    }
}