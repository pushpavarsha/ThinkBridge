using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDAL;
using ShopModel;

namespace ShopBLTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDetails()
        {
            try 
            { 
                TeaShopRepo shopRepo = new TeaShopRepo();
                IEnumerable<TeaShopVM> itemLst = shopRepo.GetDetails();

            }catch(Exception e)
            {

            }
        }
    }
}
