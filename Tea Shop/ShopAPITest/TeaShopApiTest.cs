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
        public void TestMethod1()
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
    }
}
