using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tea_Shop.Interfaces;
using Tea_Shop.Models;
using Tea_Shop.Repository;
namespace Tea_Shop.Controllers
{
    public class ShopController : Controller
    {
        ThinkBridgeEntities db = new ThinkBridgeEntities();
       
        // private IShop shop;
        //ShopController(RepositoryPat repository)
        //{
        //    shop = repository;
        //}
        // GET: Shop
        [HttpGet]
        public ActionResult GetDetails()
        {
            RepositoryPat repository = new RepositoryPat();
            IEnumerable<TeaShop> itemList = repository.GetDetails();
                //db.TeaShops.ToList();
            return View(itemList);
        }

        [HttpGet]
        public ActionResult CreateItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateItem(HttpPostedFileBase file,TeaShop teaShop)
        {
            string filename = Path.GetFileName(file.FileName);
            string _filename = DateTime.Now.ToString("yymmssff") + filename;
            string fileextension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Images/"), _filename);
            teaShop.ImageFile = "~/Images/" + _filename;

            RepositoryPat repository = new RepositoryPat();
            int success = repository.InsertDetails(teaShop);
            file.SaveAs(path);
            return RedirectToAction("GetDetails");
        }

        [HttpGet]
        public ActionResult GetItemDetail(int id)
        {
            var item = db.TeaShops.Where(x => x.ItemId == id).FirstOrDefault();
            return View(item);
        }
       
    }
}