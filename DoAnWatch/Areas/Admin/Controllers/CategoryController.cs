using DoAnWatch.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Areas.Admin.Controllers
{

    public class CategoryController : Controller
    {
        ApplicationDbContext _dbcontext = new ApplicationDbContext();
        // GET: Admin/Category

        //TÌm kiếm kết hợp Phân trang 
        public ActionResult Index( string currentFilter,  int? page, string searchString)
        {

            var item = new List<Category>();

           
            if (searchString != null) /*nếu ô tìm kiếm bằng null thì trả page về = 1*/
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            if (!string.IsNullOrEmpty(searchString))
            {
                item = _dbcontext.categories.Where(x => x.Title.Contains(searchString) || searchString == null).ToList();

            }
            else
            {
                item = _dbcontext.categories.ToList();
            }
            ViewBag.CurrentFilter = searchString;
            int pageIndex =(page ?? 1 );
            int pagesize = 2;
            item = item.OrderByDescending(n => n.Id).ToList();
            //ViewBag.PageSize = pagesize;
            //ViewBag.Page = page; 
            return View(item.ToPagedList(pageIndex, pagesize));
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category cate)
        {
            if (ModelState.IsValid)
            {
                cate.ModifiedDate = DateTime.Now;
                cate.CreatedDate = DateTime.Now;
                _dbcontext.categories.Add(cate);
                _dbcontext.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(cate);
        }
        [HttpGet]
        public ActionResult edit(int id)
        {
            var category = _dbcontext.categories.Find(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult edit(Category category)

        {


            if (ModelState.IsValid)
            {
                _dbcontext.categories.Attach(category);
                category.ModifiedDate = DateTime.Now;
                _dbcontext.Entry(category).Property(x => x.Title).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.Description).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.SeoKeywords).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.SeoTitle).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.SeoDescription).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.Position).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.ModifiedDate).IsModified = true;
                _dbcontext.Entry(category).Property(x => x.Modifiedby).IsModified = true;
                _dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        //Xóa Không load trang khác  

        public ActionResult Delete(int? id)
        {

            var category = _dbcontext.categories.Find(id);
            _dbcontext.categories.Remove(category);
            _dbcontext.SaveChanges();
            return RedirectToAction("Index");

        }





        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var category = _dbcontext.categories.Find(id);

        //    return View(category);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id)
        //{
        //    var category = _dbcontext.categories.Find(id);
        //    _dbcontext.categories.Remove(category);
        //    _dbcontext.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
        
}