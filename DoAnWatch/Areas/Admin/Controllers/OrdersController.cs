using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Data;

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
        public ActionResult xem(int? page , DateTime? startDate, DateTime? endDate) /*3 biến phân trang , tìm kiếm từ startDate tới endDate*/
        {
            
            var orders = new List<Order>();
            decimal SumBydate = 0;
            if ((startDate != null) && (endDate != null)) /*nếu tìm kiếm khác null*/
            {
                //thì nó trả toàn bộ danh sách 
                orders = _dbcontext.Orders.Where(o => o.CreatedDate >= startDate && o.CreatedDate <= endDate).ToList();
                SumBydate = orders.Sum(x => x.TotalAmount);
                
            }
            else
            {
                //ngược lại trả toàn bộ sản phẩm
                orders = _dbcontext.Orders.ToList();
            }
            if (page == null)
            {
                page = 1;
            }
           
      
            var countgia = _dbcontext.Orders.OrderByDescending(x => x.TotalAmount).Count().ToString();
            decimal sumdonhang = _dbcontext.Orders.Sum(x => x.TotalAmount);
            var sosanphambanduoc = _dbcontext.Orders.Sum(x=>x.Quatity).ToString();




            ViewBag.SumBydate = SumBydate;
            ViewBag.Sumdonhang = sumdonhang;
            ViewBag.countsp = countgia;


            ViewBag.starDate = startDate;
            ViewBag.endDate = endDate;

            //nếu page có giá trị null thì pageNumber sẽ = 1 còn nếu page có giá trị khác thì pageNumber sẽ = giá trị của page
            var pageNumber = page ?? 1;
            //danhsách có 5 sản phầm
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(orders.ToPagedList(pageNumber , pageSize));
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
        public ActionResult ThongKeDoanhThu()
        {

            var item = _dbcontext.Orders.ToList();
            var sumdonhang = _dbcontext.Orders.Sum(x => x.TotalAmount);
            //ViewBag.Sumdonhang = sumdonhang;

            return View(item);
        }
    }
}