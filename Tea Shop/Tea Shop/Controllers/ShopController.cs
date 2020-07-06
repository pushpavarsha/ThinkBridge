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
           // IEnumerable<TeaShopVM> itemList = null;
           // itemList = shop.GetItemDetails();
            //if (itemList.Count() > 0)
            //{
            //    itemList = Enumerable.Empty<TeaShopVM>();
            //    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //}
            IEnumerable<TeaShopVM> itemList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop/");
                var responseTask = client.GetAsync("SaleDetails");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TeaShopVM>>();
                    readTask.Wait();

                    itemList = readTask.Result;
                }
                else
                {
                    itemList = Enumerable.Empty<TeaShopVM>();


                }
               // return itemList;

            }
            return View(itemList);
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
            return View();
        }
       
    }
}