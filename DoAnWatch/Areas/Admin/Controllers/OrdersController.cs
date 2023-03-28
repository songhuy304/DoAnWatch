using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace DoAnWatch.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        ApplicationDbContext _dbcontext = new ApplicationDbContext();
        // GET: Admin/Orders
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult xem(int? page)
        {
            var item = _dbcontext.Orders.OrderByDescending(x => x.CreatedDate).ToList();
            if(page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
           
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(item.ToPagedList(pageNumber , pageSize));
        }
        public ActionResult Chitiet(int id)
        {
            var item = _dbcontext.Orders.Find(id);
            return View(item);
        }
        public ActionResult Partial_SanPham(int id)
        {
            var item = _dbcontext.OrderDetails.Where(x=>x.OrderId == id).ToList();
            return PartialView(item);
        }
    }
}