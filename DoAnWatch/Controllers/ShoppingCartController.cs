using DoAnWatch.Models;
using Microsoft.Ajax.Utilities;
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
            if (cart != null && cart.Items.Any())
            {

                ViewBag.Checkcard = cart;
            }
            
            return View();
        }
        public ActionResult CheckOut()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                ViewBag.Checkcard = cart;
            }
            return View();
        }
  
        public ActionResult Partial_CheckOut()
        {
           
            return PartialView();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckOut(OrderViewModel req)
        {
            
            var code = new {Success =false , Code = -1};
            if (ModelState.IsValid)
            {
                ShoppingCart cart = (ShoppingCart)Session["Cart"];
                if (cart != null)
                {
                  

                    Order order = new Order();
                    order.CustomerName = req.CustomerName;
                    order.Phone = req.Phone;
                    order.Address = req.Address;
                    order.Email = req.Email;
                    cart.Items.ForEach(x => order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = x.ProductId,
                        Quantity = x.Quantity,
                        Price = x.Price,

                    }));
                    foreach (var item in cart.Items)
                    {
                        var product = db.Products.Find(item.ProductId);
                        if (product != null)
                        {

                            if (product.Quantity < item.Quantity)
                            {
                                string messs = "Xin lỗi có Sản phẩm bị quá cho phép! ";
                                string script11 = "alert('" + messs + "');";
                                return Content("<script type='text/javascript'>" + script11 + "window.location.href='/ShoppingCart/index';</script>");

                            }
                            else
                            {
                                product.Quantity -= item.Quantity;

                            }
                        }
                    }
                    order.TotalAmount = cart.Items.Sum(x=>(x.Price *x.Quantity));
                    order.TypePayment = req.Payment;
                    order.CreatedDate = DateTime.Now;
                    order.CreatedBy = req.Phone;
                    order.ModifiedDate = DateTime.Now;
                    Random rd = new Random();
                    order.Code = "A6" + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9) + rd.Next(0, 9);
                    db.Orders.Add(order);
                    
                    db.SaveChanges();
                    cart.ClearCart();

                    string message = "Đặt hàng thành công!";
                    string script = "alert('" + message + "');";
                    return Content("<script type='text/javascript'>" + script + "window.location.href='/home/index';</script>");

                }
            }
            return Json(code);
        }
        public ActionResult Partial_Item_Cart()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return View(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_Item_ThanhToan()
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null && cart.Items.Any())
            {
                return View(cart.Items);
            }
            return PartialView();
        }
        public ActionResult Partial_soluongcon()
        {
            
            return PartialView();
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
            //Nếu trong quá trình xử lý hàm, có một lỗi xảy ra hoặc không có giá trị nào được trả về,
            //giá trị code trong đối tượng vô danh sẽ giữ nguyên giá trị -1.Tùy theo trường hợp,
            //mã lỗi này có thể được sử dụng để hiển thị thông báo lỗi hoặc xử lý các trường hợp đặc biệt khác.
            //Ví dụ, khi đối tượng vô danh trả về có Success = false, msg chứa thông báo lỗi, code = -1, và Count = 0,
            //có thể hiển thị thông báo lỗi "Có lỗi xảy ra trong quá trình xử lý" và không cập nhật giỏ hàng.
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
        public ActionResult RemoveCartItem(int id)
        {
            ShoppingCart cart = (ShoppingCart)Session["Cart"];
            if (cart != null)
            {
                cart.Remove(id);
                Session["Cart"] = cart;
            }

            return RedirectToAction("Index");
        }
        [HttpPost]
      
        public ActionResult Update_Quantity_Cart(FormCollection form)
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            int id_pro = int.Parse(form["ID_Product"]);
            int quantity = int.Parse(form["Quantity"]);
            var item = cart.Items.FirstOrDefault(i => i.ProductId == id_pro);
            if (item != null)
            {
                var product = db.Products.Find(item.ProductId);
                if (product != null)
                {
                    if (product.Quantity < quantity)
                    {
                        
                        string messs = "có Sản phẩm bị quá cho phép " + product.Title + "chỉ còn" + product.Quantity;
                        
                        string script11 = "alert('" + messs + "');";
                        return Content("<script type='text/javascript'>" + script11 + "window.location.href='/ShoppingCart/index';</script>");

                        //ViewBag.ErrorMessage = $"Sản phẩm {product.Title} chỉ còn {product.Quantity} trong kho.";
                    }
                    else
                    {
                        cart.UpdateQuantity(id_pro, quantity);
                    }
                }
            }
            return RedirectToAction("Index", "ShoppingCart");


        }
        [HttpPost]
       
      
        public ActionResult ClearCart()
        {
            // Xóa giỏ hàng trong phiên hiện tại
            Session["Cart"] = null;
            // Chuyển hướng đến trang giỏ hàng
            return RedirectToAction("Index", "ShoppingCart");
        }



    }
}