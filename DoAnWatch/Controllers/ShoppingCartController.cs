using DoAnWatch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Controllers
{
    public class ShoppingCartController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult Index()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if( cart != null)
            {
                return View(cart.Items);
            }
            return View();
        }
        public ActionResult ShowCount()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if(cart != null)
            {
                return Json(new{ Count = cart.Items.Count},JsonRequestBehavior.AllowGet);
            }
            return Json(new { Count = 0 }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult AddToCart(int id  , int quantity)
        {
            var code = new { Success = false, msg = "", code = -1 , Count = 0};
            var checkProduct  = db.Products.FirstOrDefault(p => p.Id == id);    
            if(checkProduct != null)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if(cart == null)
                {
                    cart = new ShoppingCart();
                }
                ShoppingCartItem item = new ShoppingCartItem
                {
                    ProductId = checkProduct.Id,
                    ProductName = checkProduct.Title,
                    CategoryName = checkProduct.ProductCategory.Title,
                    Quantity = quantity,
                };
                if(checkProduct.Image != null)
                {
                    item.Image = checkProduct.Image;    

                }
                item.Price = checkProduct.Price;
                //if (checkProduct.PriceSale > 0)
                //{
                //    item.Price = (decimal)checkProduct.PriceSale;
                //}
                item.TotalPrice = item.Price * item.Quantity;
                cart.AddToCart(item, quantity);
                Session["Cart"] = cart;
                code = new { Success = true, msg = "Thêm Thành Công", code = 1 , Count = cart.Items.Count };
            }
            return Json(code);
        }
        public ActionResult ClearCart()
        {
            // Xóa giỏ hàng trong phiên hiện tại
            Session["Cart"] = null;
            // Chuyển hướng đến trang giỏ hàng
            return RedirectToAction("Index", "ShoppingCart");
        }


        //public ActionResult RemoveCartItem(int id , int quantity = 1)
        //{
        //    ShoppingCartItem cart = (ShoppingCartItem)Session["Cart"];
        //    if (cart != null)
        //    {
        //        cart.RemoveFromCart(id, quantity);
        //        Session["Cart"] = cart;
        //    }
        //    return RedirectToAction("Cart");
        //}


    }
}