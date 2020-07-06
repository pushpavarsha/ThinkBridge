using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopBU;
using ShopModel;

namespace ShopBUTest
{
    [TestClass]
    public class TeaShopBUTest
    {
        [TestMethod]
        public void GetDetails()
        {
            try
            {
                TeaShopBU item = new TeaShopBU();
                IEnumerable<TeaShopVM> itemList = item.GetItemDetails();
            }catch(Exception ex)
            {

            }

        }
    }
}
