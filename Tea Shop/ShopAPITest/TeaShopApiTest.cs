using System;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopAPI;

namespace ShopAPITest
{
    [TestClass]
    public class TeaShopApiTest
    {
        [TestMethod]
        public void Details()
        {
            try
            { 
                TeaShopController teaShopCont = new TeaShopController();
                teaShopCont.Request = new HttpRequestMessage();
                teaShopCont.Configuration = new HttpConfiguration();
                var detaills =teaShopCont.SaleDetails();
            }catch(Exception ex)
            {

            }
        }

        [TestMethod]
        public void  Delete()
        {
            try
            { 
                TeaShopController teaShopCont = new TeaShopController();
                teaShopCont.Request = new HttpRequestMessage();
                var details = teaShopCont.DeleteItem(5);
            }catch(Exception ex)
            {

            }

        }
    }
}
