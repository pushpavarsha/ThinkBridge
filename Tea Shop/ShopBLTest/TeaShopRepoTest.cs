using System;
using System.Collections.Generic;
using System.Linq;
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
                //int[] arr = { 1, 2, 3, 4, 5 };
                IEnumerable<TeaShopVM> itemLst =shopRepo.GetDetails();
               itemLst = itemLst.Take(1);

            }catch(Exception e)
            {

            }
        }
        
        [TestMethod]
        public void TestItemDetails()
        {
            try
            {
                TeaShopRepo shopRepo = new TeaShopRepo();
                TeaShopVM itemLst = shopRepo.GetDetailsById(35);

            }
            catch (Exception e)
            {

            }

        }
        [TestMethod]
        public void DeleteDetails()
        {
            try
            {
                TeaShopRepo shopRepo = new TeaShopRepo();
                shopRepo.DeleteDetails(35);

            }
            catch (Exception e)
            {

            }

        }
    }
}
