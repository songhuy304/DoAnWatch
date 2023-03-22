using DoAnWatch.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        public ApplicationDbContext _dbcontext = new ApplicationDbContext();
        // GET: Admin/Product
        public ActionResult Index(int? page)
        {
            //var products = _dbcontext.Products;
            IEnumerable<Product> item = _dbcontext.Products.OrderByDescending(x => x.Id);
            var pagesize = 5;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            item = item.ToPagedList(pageIndex, pagesize);
            return View(item);
        }
        public ActionResult Add()
        {
            ViewBag.productCategory = new SelectList(_dbcontext.ProductCategogies.ToList(), "Id", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {

                _dbcontext.Products.Add(product);
                _dbcontext.SaveChanges();



                return RedirectToAction("Index");
            }
            ViewBag.productCategory = new SelectList(_dbcontext.ProductCategogies.ToList(), "Id", "Title");
            return View(product);
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            ViewBag.productCategory = new SelectList(_dbcontext.ProductCategogies.ToList(), "Id", "Title");

            var product = _dbcontext.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult edit(Product product)

        {


            if (ModelState.IsValid)
            {
                _dbcontext.Products.Attach(product);
                _dbcontext.Entry(product).State = System.Data.Entity.EntityState.Modified;

                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }
        //Xóa Không load trang khác  

        public ActionResult Delete(int? id)
        {

            var product = _dbcontext.Products.Find(id);
            _dbcontext.Products.Remove(product);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult detail(int? id)
        {
            var product = _dbcontext.Products.SingleOrDefault(m=>m.Id == id);
            ViewBag.Id = product.Id;

            return View(product);
        }
    } 
}