using DoAnWatch.Models;
using DoAnWatch.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAnWatch.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        ApplicationDbContext db = new ApplicationDbContext();
        [HttpGet]
        public ActionResult Login()
        {
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Login(Userr userr)
        {
            
            if (ModelState.IsValid)
            {
                var f_password = userr.Password;
                var userlogin1 = db.userrs.Where(s => s.Username.Equals(userr.Username) && s.IsAdmin == null && s.Password.Equals(f_password));
                var userlogin = db.userrs.Where(s => s.Username.Equals(userr.Username) && s.IsAdmin == true &&  s.Password.Equals(f_password));
                if (userlogin1.Count() > 0)
                {
                    //add session
                    Session["FullName"] = userlogin.FirstOrDefault().Fullname;
                    Session["Username"] = userlogin.FirstOrDefault().Username;
                    Session["UserID"] = userlogin.FirstOrDefault().UserID;
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                if (userlogin1.Count() > 0)
                {
                    //add session
                    Session["FullName"] = userlogin1.FirstOrDefault().Fullname;
                    Session["Username"] = userlogin1.FirstOrDefault().Username;
                    Session["UserID"] = userlogin1.FirstOrDefault().UserID;
                    return RedirectToAction("Index", "Home");
                }

                else
                {
                    string message = "Đăng Nhập Không Thành Công!";
                    string script = "alert('" + message + "');";
                    return Content("<script type='text/javascript'>" + script + "window.location.href='/login/login';</script>");
                }
            }
            else
            {
                return View(userr);

               
            }
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Userr usr)
        {
            if (ModelState.IsValid)
            {
                var check = db.userrs.FirstOrDefault(p => p.Username == usr.Username);
                if (check == null)
                {
                    db.userrs.Add(usr);
                    db.SaveChanges();
                    return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.error = "Tên Người Dùng đã tồn tại !";
                    return View();
                }
            }
            return View();
        }



        public ActionResult Logout()
        {
            Session.Remove("UserID");
            Session.Remove("FullName");
            Session.Remove("Username");
            return RedirectToAction("Login", "Login");
        }
    }
}