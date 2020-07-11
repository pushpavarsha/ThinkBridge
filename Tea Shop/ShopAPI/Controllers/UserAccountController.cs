using ShopIDAL;
using ShopModel;
using ShopDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Dynamic;
using System.Web;
using System.Drawing.Printing;

namespace ShopAPI.Controllers
{
    public class UserAccountController : ApiController
    {
        IUserAccount repo = new UserAccountRepo();
        [HttpPost]
        public IHttpActionResult CreateAccount(UserAccountVM user)
        {
            try 
            { 
              bool flag=repo.SignUp(user);
                if(flag)
                { 
                    return Ok();
                }
                else
                {
                    dynamic response = new ExpandoObject();
                    response.message = "User already exist";
                    return Content<UserAccountVM>(HttpStatusCode.BadRequest,response);
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult UserLogin(UserAccountVM user)
        {
            try
            {
                bool flag = repo.UserValidation(user);
                if (flag)
                    return Ok();
                else
                {
                    dynamic response = new ExpandoObject();
                    response.message = "Invalid User";
                    return Content<UserAccountVM>(HttpStatusCode.BadRequest, response);
                }

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPut]
        public IHttpActionResult RestPassword(UserAccountVM _user)
        {
            try
            {
                bool flag = repo.RestPassword(_user);
                if(flag)
                {
                    return Ok("Password has been reset ");
                }
                else
                {
                    dynamic response = new ExpandoObject();
                    response.message = "Password Cant be  reset";
                    return Content<UserAccountVM>(HttpStatusCode.BadRequest, response);
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
