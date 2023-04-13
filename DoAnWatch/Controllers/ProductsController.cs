using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DoAnWatch.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Products
        public ActionResult Index(string currentFilter, int? page, string searchString , int? category)
        {
            var item = new List<Product>();


            if (!string.IsNullOrEmpty(searchString))
            {
                if (category.HasValue && category.Value != 0)
                {
                    item = db.Products.Where(x => x.Title.Contains(searchString) && x.ProductCategoryId == category.Value).ToList();    
                   
                }
                else
                {
                    item = db.Products.Where(x => x.Title.Contains(searchString)).ToList();
                    ViewBag.Category = null;
                }
                page = 1;
              
            }
            else if (category.HasValue && category.Value != 0)
            {
                item = db.Products.Where(x => x.ProductCategoryId == category.Value).ToList();
                ViewBag.Category = category;

            }
            else
            {
                item = db.Products.ToList();
                ViewBag.Category = null;
            }
        
            ViewBag.CategoryList = new SelectList(db.ProductCategogies.ToList(), "Id", "Title");

           


            ViewBag.CurrentFilter = searchString;
            int pageIndex = page ?? 1;
            int pagesize = 10; 
            item = item.OrderByDescending(n => n.Id).ToList();
            //ViewBag.PageSize = pagesize;
            //ViewBag.Page = page;
            return View(item.ToPagedList(pageIndex, pagesize));

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
       
        public ActionResult Partial_ItemsBySale()
        {
            var items = db.Products.Where(x => x.IsHome == true && x.IsSale == true).ToList();
            return PartialView(items);
        }
    }
}