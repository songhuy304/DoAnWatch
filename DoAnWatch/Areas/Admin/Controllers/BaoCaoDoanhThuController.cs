using DoAnWatch.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Areas.Admin.Controllers
{
    public class BaoCaoDoanhThuController : Controller
    {
        // GET: Admin/BaoCaoDoanhThu
        ApplicationDbContext _dbcontext = new ApplicationDbContext();
      
        public ActionResult Index(int? page, DateTime? startDate)
        {
            //tạo ra 1 cái list đơn hàng 
                var orders = new List<Order>();
            decimal SumBydate = 0;

            if ((startDate != null))
            {
                orders = _dbcontext.Orders.Where(o => o.CreatedDate.Month == startDate.Value.Month/* && o.CreatedDate <= endDate*/).ToList();
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
            ViewBag.SumBydate = SumBydate;

            var countgia = _dbcontext.Orders.OrderByDescending(x => x.TotalAmount).Count().ToString();

            decimal sumdonhang = _dbcontext.Orders.Sum(x => x.TotalAmount);
            var sosanphamban = _dbcontext.OrderDetails.Sum(x => x.Quantity);

            ViewBag.sosanphamban = sosanphamban;
            ViewBag.Sumdonhang = sumdonhang;
            ViewBag.countsp = countgia;




            //if (startDate.HasValue)
            //{
            //    ViewBag.startDate = startDate.Value.ToString("MM");
            //}
            //else
            //{
                
            //}

            ViewBag.startDate1 = startDate?.ToString("MM");
           
            //ViewBag.endDate = endDate;


            var pageNumber = page ?? 1;
            var pageSize = 5;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(orders.ToPagedList(pageNumber, pageSize));
        }
    }
}