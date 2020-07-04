using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tea_Shop.Models;

namespace Tea_Shop.Controllers
{
    public class TeaApiController : ApiController
    {
        
        [HttpGet]
        public IHttpActionResult SaleDetails()
        {
            using (ThinkBridgeEntities db = new ThinkBridgeEntities())
            {
                //Linq Query
                IEnumerable<TeaShop> item = db.TeaShops.ToList();
                if (item.Count() == 0)
                {
                    return NotFound();
                }

                return Ok(item);
            }
        }
        [HttpPost]
        public IHttpActionResult AddItem(TeaShop teaShop)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            using (ThinkBridgeEntities db=new ThinkBridgeEntities())
            {
                db.TeaShops.Add(teaShop);
                db.SaveChanges();
                
            }
            return Ok(1);

        }
    }
}
