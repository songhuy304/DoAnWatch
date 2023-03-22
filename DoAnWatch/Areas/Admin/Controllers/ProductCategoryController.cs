using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        ApplicationDbContext _dbcontext = new ApplicationDbContext();
        // GET: Admin/ProductCategory
        public ActionResult Index()
        {
            var item = _dbcontext.ProductCategogies;
            return View(item);
        }
        
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategogy productcate)
        {
            if (ModelState.IsValid)
            {
                productcate.ModifiedDate = DateTime.Now;
                productcate.CreatedDate = DateTime.Now;
                _dbcontext.ProductCategogies.Add(productcate);
                _dbcontext.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(productcate);
        }
    }
}