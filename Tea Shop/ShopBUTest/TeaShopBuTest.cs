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
        [TestMethod]
        public void Insert()
        {
            try
            {
                TeaShopBU obj = new TeaShopBU(); 
                TeaShopVM shop = new TeaShopVM()
                {
                    ItemName = "ABC",
                    Price = 123,
                    ImageFile = "abc.jpeg",
                    Description = "abc"
                };
                bool flag=obj.InsertItem(shop);


            }catch(Exception ex)
            {

            }
        }
    }
}
