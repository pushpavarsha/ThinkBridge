using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ShopModel;
using System.Net.Http;

namespace Tea_Shop.Controllers
{
    public class ShopController : Controller
    {
              
        [HttpGet]
        public ActionResult GetDetails()
        {
            IEnumerable<TeaShopVM> itemList = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop");
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

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }

            }
            return View(itemList);
        }
        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateItem(HttpPostedFileBase file,TeaShopVM teaShop)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssff") + filename;
            string fileextension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
            teaShop.ImageFile = "~/Images/" + _filename;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44393/api/TeaShop");
                var postTask = client.PostAsJsonAsync<TeaShopVM>("AddItem", teaShop);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetDetails");
                }
                file.SaveAs(path);
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");                    
            return View(teaShop);
        }

        [HttpGet]
        public ActionResult GetItemDetail(int id)
        {        
            return View();
        }
       
    }
}