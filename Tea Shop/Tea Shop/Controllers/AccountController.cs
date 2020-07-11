using ShopBU;
using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Tea_Shop.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        UserAccountBU account = new UserAccountBU();
        // GET: Account
        public ActionResult Login()
        {
            if (TempData.ContainsKey("msg"))
                ViewBag.Message = TempData["msg"].ToString();
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccountVM user)
        {
            bool flag = account.SignIn(user);
            if(flag)
            {
                return RedirectToAction("GetDetails", "Shop");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User");
            }
            return View();
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserAccountVM user)
        {
            bool flag = account.SignUp(user);
            if(flag)
               return RedirectToAction("Login");
            else
            { 
                ModelState.AddModelError("", " User Already Exits");
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult About()
        {
            return View();
        }
    }
}