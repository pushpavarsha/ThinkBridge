using Microsoft.Ajax.Utilities;
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
                FormsAuthentication.SetAuthCookie(user.EmailId, false);
                return RedirectToAction("GetDetails", "Shop");
            }
            else
            {
                ModelState.AddModelError("", "Invalid User or Wrong Password");
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
            bool flag=false;
            if (!user.Password.Equals(user.ConfirmPassword))
            {
                ModelState.AddModelError("", "Password and Confirm Password Doesn't match");
                return View();
            }
            else
            {
                flag = account.SignUp(user);
                if (flag)
                {
                    TempData["msg"] = 2;
                    return RedirectToAction("Login");
                }
                else
                {

                    ModelState.AddModelError("", " User Already Exits");
                    return View();
                }
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

        [HttpGet]
        public ActionResult RestCredential()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RestCredential(UserAccountVM user)
        {
            bool flag = false;
            if (!user.Password.Equals(user.ConfirmPassword))
            {
                ModelState.AddModelError("", "Password and Confirm Password Doesn't match");
                return View();
            }
            else
            {
                flag = account.RestPassword(user);
                if (flag)
                {
                    TempData["msg"] = 1;
                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError("", "Please Register yourself,User doesn't exist or You are entering something wrong");
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Images()
        {
            return View();
        }
    }
}