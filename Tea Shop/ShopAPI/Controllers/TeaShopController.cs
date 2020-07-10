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
            try 
            { 
                var details = db.GetDetails();
                if(details.Count()==0)
                {
                    return NotFound();
                }
                return Ok(details);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
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

        [HttpGet]
        [Route("api/TeaShop/GetItemById/{itemId}")]
        public IHttpActionResult GetItemById(int itemId)
        {
            try
            {
               TeaShopVM item= db.GetDetailsById(itemId);
                return Ok(item);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpDelete]
        [Route("api/TeaShop/DeleteItem/{itemId}")]
        public IHttpActionResult DeleteItem(int itemId)
        {
            try
            {
                db.DeleteDetails(itemId);
                return Ok();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }

        }

        [HttpPut]
        public IHttpActionResult UpdateItem(TeaShopVM item)
        {
            try
            {
                db.UpdateDetails(item);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

    }
} 
