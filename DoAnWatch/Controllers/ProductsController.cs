using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(string searchString)
        {
            ViewBag.Keyword = searchString;
            var items = db.Products.Where(x => x.Title.Contains(searchString) || searchString == null);

            //if (categoryID != 0)
            //{
            //    items = db.Products.Where(x => x.ProductCategoryId == categoryID);
            //}
            //ViewBag.ProductCategoryID = new SelectList(db.ProductCategogies.ToList(), "Id", "Title");


            return View(/*db.Products.Where(x => x.Title.Contains(searchString) || searchString == null).ToList()*/items.ToList());

        }
        public ActionResult detail(int? id)
        {
            var items = db.Products.Find(id);
            return View(items);
        }

        public ActionResult Partial_ItemsByCateId()
        {
            var items = db.Products.Where(x=>x.IsHome == true).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ItemsByCateIddd()
        {
            var items = db.Products.Where(x => x.IsHome == true).ToList();
            return PartialView(items);
        }
        public ActionResult Partial_ItemsBySale()
        {
            var items = db.Products.Where(x => x.IsHome == true && x.IsSale == true).ToList();
            return PartialView(items);
        }
    }
}