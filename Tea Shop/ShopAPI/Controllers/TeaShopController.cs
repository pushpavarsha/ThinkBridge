using ShopDAL;
using ShopIDAL;
using ShopModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace ShopAPI
{
    public class TeaShopController : ApiController
    {
        ITeaShop db = new TeaShopRepo();
        
        [HttpGet]
        public IHttpActionResult SaleDetails()
        {
            var details = db.GetDetails();
            if(details.Count()==0)
            {
                return NotFound();
            }
            return Ok(details);                    
        }
        [HttpPost]
        public IHttpActionResult AddItem(TeaShopVM teaShop)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.InsertDetails(teaShop);
                    if(true)
                    {
                        return Ok("Successfully Inserted");
                    }
                }
                else
                {
                    return BadRequest("Error Please check");
                }

            }catch(Exception e)
            {
                return BadRequest(e.Message.ToString());
            }

        }
    }
} 
