using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
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
            var orders = new List<ProductCategogy>();
           
            
                //ngược lại trả toàn bộ sản phẩm
                orders = _dbcontext.ProductCategogies.ToList();
            


            //decimal totalRevenue = orders.Sum(o => o.TotalPrice);

            //ViewBag.TotalRevenue = totalRevenue;

            return View(orders);

            //return View(_dbcontext.ProductCategogies.Where(x=>x.Title.Contains(searchString) || searchString == null).ToList());
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
        [HttpGet]
        public ActionResult edit(int id)
        {
            //tìm kiếm sản phầm để chĩnh sửa
            var productCategogy = _dbcontext.ProductCategogies.Find(id);

            return View(productCategogy);
        }
        [HttpPost]
        public ActionResult edit(ProductCategogy productcate)

        {



            if (ModelState.IsValid)
            {
                _dbcontext.ProductCategogies.Attach(productcate);
                _dbcontext.Entry(productcate).State = System.Data.Entity.EntityState.Modified;

                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productcate);
            
        }
        //Xóa Không load trang khác  

        public ActionResult Delete(int? id)
        {

            var productCategogy = _dbcontext.ProductCategogies.Find(id);
            _dbcontext.ProductCategogies.Remove(productCategogy);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}