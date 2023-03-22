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
        public ActionResult Index(int? page)
        {
            var pagesize = 2;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = Convert.ToInt32(page);
            var item = _dbcontext.categories.OrderBy(x => x.Id).ToPagedList(pageIndex, pagesize);
            ViewBag.PageSize = pagesize;
            ViewBag.Page = page; 
            return View(item);
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