using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShopModel;
using System.Net.Http;
using ShopBU;

namespace Tea_Shop.Controllers
{
    public class ShopController : Controller
    {

        TeaShopBU shop = new TeaShopBU();

        [HttpGet]
        public ActionResult GetDetails()
        {
            IEnumerable<TeaShopVM> list = shop.GetItemDetails();      
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateItem(HttpPostedFileBase file,TeaShopVM _item)
        {
            string _filename = DateTime.Now.ToString("yymmssff") + Path.GetFileName(file.FileName);
            _item.ImageFile = "~/Images/" + _filename;
            bool flag=shop.InsertItem(_item);
            if(flag)
            { 
                string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
                file.SaveAs(path);
                return RedirectToAction("GetDetails");
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");                    
            return View("GetDetails");
        }

        [HttpGet]
        public ActionResult GetItemDetail(int id)
        {
            TeaShopVM tea = shop.GetItemById(id);
            return View(tea);
        }

       
        [HttpGet]
        public ActionResult EditItem(int id)
        {
            TeaShopVM tea = shop.GetItemById(id);
            return View(tea);
        }

        [HttpPost]
        public ActionResult EditItem(HttpPostedFileBase file,TeaShopVM item)
        {
            string _filename = DateTime.Now.ToString("yymmssff") + Path.GetFileName(file.FileName);
            item.ImageFile = "~/Images/" + _filename;
            bool flag = shop.UpdateItem(item);
            if (flag)
            {
                string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
                file.SaveAs(path);
                return RedirectToAction("GetDetails");
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");
           
            return RedirectToAction("GetDetails");
        }
        [HttpGet]
        public ActionResult DeleteItem(int id)
        {
            bool flag = shop.DeleteItem(id);
            if(flag)
            {
                return RedirectToAction("GetDetails");
                //return Content("Delete Successfully");
            }
            return RedirectToAction("GetDetails");
           // return Content("Can't be deleted");
        }
       
      
    }
}